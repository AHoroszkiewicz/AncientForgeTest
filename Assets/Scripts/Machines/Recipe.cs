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
    [SerializeField] private Image image;

    private MachinePanel machinePanel;

    public void Initialize(List<ItemsEnum> inputs, ItemsEnum output, float time, float success, InventoryManager inventoryManager, MachinePanel machinePanel)
    {
        List<Item> items = inventoryManager.Items;
        this.machinePanel = machinePanel;
        this.inputs = inputs;
        this.output = output;

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

    public void SelectCrafting()
    {
        machinePanel.SelectCrafting(inputs, output, this);
    }

    public void SelectImage(bool select)
    {
        image.color = select ? new Color(0.2154236f, 0.6544291f, 0.9716981f, 0.5f) : new Color(0f,0f,0f,0f);
    }
}
