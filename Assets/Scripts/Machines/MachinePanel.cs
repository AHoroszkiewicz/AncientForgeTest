using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinePanel : MonoBehaviour
{
    [SerializeField] private GameObject recipesObj;
    [SerializeField] private GameObject recipePrefab;
    [SerializeField] private List<RecipeSO> recipesSO = new List<RecipeSO>();

    private List<Recipe> recipes = new List<Recipe>();
    private Queue<Recipe> craftingQueue = new Queue<Recipe>();
    private Recipe selectedRecipe;
    private bool isCrafting = false;
    private InventoryManager inventoryManager;

    public void Initialize(InventoryManager inventoryManager)
    {
        this.inventoryManager = inventoryManager;

        foreach (var recipe in recipesSO)
        {
            var recipeObj = Instantiate(recipePrefab, recipesObj.transform);
            recipeObj.transform.SetParent(recipesObj.transform);
            Recipe recipeComp = recipeObj.GetComponent<Recipe>();
            recipeComp.Initialize(recipe, this.inventoryManager, this);
            recipes.Add(recipeComp);
        }
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
            Debug.Log("Not enough resources"); //TODO
            return;
        }
        foreach (var item in inputs)
        {
            inventoryManager.RemoveItem((int)item, 1);
        }
        craftingQueue.Enqueue(selectedRecipe);
        if (!isCrafting)
        {
            isCrafting = true;
            StartCoroutine(Crafting());
        }
    }

    private IEnumerator Crafting()
    {
        while (craftingQueue.Count > 0)
        {
            var recipe = craftingQueue.Peek();
            yield return new WaitForSeconds(recipe.Time);
            if (Random.Range(0, 1) < recipe.SuccessRate)
            {
                inventoryManager.AddItem((int)craftingQueue.Dequeue().Output, 1);
            }
            else
            {
                Debug.Log("Crafting failed"); //TODO
            }
        }
        isCrafting = false;
    }
}
