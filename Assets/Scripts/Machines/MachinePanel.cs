using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MachinePanel : MonoBehaviour
{
    [SerializeField] private GameObject recipesObj;
    [SerializeField] private GameObject recipePrefab;
    [SerializeField] private List<RecipeSO> recipesSO = new List<RecipeSO>();
    private List<Recipe> recipes = new List<Recipe>();

    private List<ItemsEnum> craftingInput;
    private ItemsEnum craftingOutput;

    private InventoryManager inventoryManager;

    public void Initialize(InventoryManager inventoryManager)
    {
        this.inventoryManager = inventoryManager;

        foreach (var recipe in recipesSO)
        {
            var recipeObj = Instantiate(recipePrefab, recipesObj.transform);
            recipeObj.transform.SetParent(recipesObj.transform);
            Recipe recipeComp = recipeObj.GetComponent<Recipe>();
            recipeComp.Initialize(recipe.Input, recipe.Output, recipe.Time, recipe.SuccessRate, this.inventoryManager, this);
            recipes.Add(recipeComp);
        }
    }

    public void SelectCrafting(List<ItemsEnum> inputs, ItemsEnum output, Recipe recipe)
    {
        craftingInput = inputs;
        craftingOutput = output;
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
        Debug.Log(craftingInput + " , " + craftingOutput);
        if (craftingInput == null || craftingOutput == ItemsEnum.None)
        {
            return;
        }
        foreach (var item in craftingInput)
        {
            inventoryManager.RemoveItem((int)item, 1);
        }
        inventoryManager.AddItem((int)craftingOutput, 1);
    }
}
