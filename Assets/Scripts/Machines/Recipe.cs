using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    private List<ItemsEnum> inputs = new List<ItemsEnum>();
    private ItemsEnum output;

    [SerializeField] private GameObject itemsObj;
    [SerializeField] private GameObject inputObj;
    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] private TextMeshProUGUI successTxt;
    [SerializeField] private GameObject emptyGameObject;

    public void SetRecipe(List<ItemsEnum> inputs, ItemsEnum output, float time, float success)
    {
        List<Item> items = InventoryManager.Instance.Items;

        foreach (var input in inputs)
        {
            var item = Instantiate(emptyGameObject, transform);
            Image itemImage = item.AddComponent<Image>();
            itemImage.sprite = items[(int)input-1].ItemImage.sprite;
            itemImage.preserveAspect = true;
            item.transform.SetParent(inputObj.transform);
        }
        var outputItem = Instantiate(emptyGameObject, transform);
        Image outputImage = outputItem.AddComponent<Image>();
        outputImage.sprite = items[(int)output-1].ItemImage.sprite;
        outputImage.preserveAspect = true;
        outputItem.transform.SetParent(itemsObj.transform);

        timeTxt.text = "Time: " + time.ToString() + "s";
        successTxt.text = "Success: " + (success*100).ToString() + "%";

    }
}
