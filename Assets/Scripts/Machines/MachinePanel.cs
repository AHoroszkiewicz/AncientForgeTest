using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachinePanel : MonoBehaviour
{
    [SerializeField] private GameObject recipesObj;
    [SerializeField] private GameObject recipePrefab;
    [SerializeField] private List<RecipeSO> recipesSO = new List<RecipeSO>();
    [SerializeField] private Button button;
    [SerializeField] private Machine machine;
    [SerializeField] private GameObject noResourcesObj;

    private List<Recipe> recipes = new List<Recipe>();
    private Recipe selectedRecipe;
    private InventoryManager inventoryManager;
    private MachinePanelManager machinePanelManager;
    private Coroutine noResourceCoroutine;

    public MachinePanelManager MachinePanelManager => machinePanelManager;

    public void Initialize(MachinePanelManager machinePanelManager)
    {
        this.machinePanelManager = machinePanelManager;
        inventoryManager = machinePanelManager.GameManager.InventoryManager;
        machine.Initialize(this);

        foreach (var recipe in recipesSO)
        {
            var recipeObj = Instantiate(recipePrefab, recipesObj.transform);
            recipeObj.transform.SetParent(recipesObj.transform);
            Recipe recipeComp = recipeObj.GetComponent<Recipe>();
            recipeComp.Initialize(recipe, inventoryManager, this);
            recipes.Add(recipeComp);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        noResourcesObj.SetActive(false);
        if (noResourceCoroutine != null)
            StopCoroutine(noResourceCoroutine);
        gameObject.SetActive(false);
    }

    public void SelectCrafting(Recipe recipe)
    {
        selectedRecipe = recipe;
        foreach (Recipe a in recipes)
        {
            if (a == recipe)
            {
                a.SelectImage(true);
            }
            else
            {
                a.SelectImage(false);
            }
        }
    }

    public void Craft()
    {
        bool success = true;
        if (selectedRecipe == null)
        {
            return;
        }
        List<ItemsEnum> inputs = selectedRecipe.Inputs;
        foreach (var item in inputs)
        {
            if (inventoryManager.Items[(int)item - 1].Quantity == 0)
            {
                success = false;
            }
        }
        if (!success)
        {
            noResourceCoroutine = StartCoroutine(NoResources());
            return;
        }
        foreach (var item in inputs)
        {
            inventoryManager.RemoveItem((int)item, 1);
        }
        machine.Craft(selectedRecipe);
    }

    public void Unlock()
    {
        button.interactable = true;
    }

    private IEnumerator NoResources()
    {
        if (noResourceCoroutine != null)
        {
            StopCoroutine(noResourceCoroutine);
        }
        noResourcesObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        noResourcesObj.SetActive(false);
    }
}
