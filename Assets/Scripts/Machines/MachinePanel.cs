using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MachinePanel : MonoBehaviour
{
    [SerializeField] private GameObject recipesObj;
    [SerializeField] private GameObject recipePrefab;
    [SerializeField] private List<RecipeSO> recipes = new List<RecipeSO>();

    public void Initialize()
    {
        foreach (var recipe in recipes)
        {
            var recipeObj = Instantiate(recipePrefab, recipesObj.transform);
            recipeObj.transform.SetParent(recipesObj.transform);
            recipeObj.GetComponent<Recipe>().SetRecipe(recipe.Input, recipe.Output, recipe.Time, recipe.SuccessRate);
        }
    }

}
