using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    [SerializeField] private GameObject itemsObj;
    [SerializeField] private GameObject inputObj;
    [SerializeField] private TextMeshProUGUI timeTxt;
    [SerializeField] private TextMeshProUGUI successTxt;
    [SerializeField] private GameObject emptyGameObject;
    [SerializeField] private Image image;

    private List<ItemsEnum> inputs = new List<ItemsEnum>();
    private ItemsEnum output;
    private float time;
    private float successRate;
    private MachinePanel machinePanel;

    public List<ItemsEnum> Inputs => inputs;
    public ItemsEnum Output => output;
    public float Time => time;
    public float SuccessRate => successRate;

    public void Initialize(RecipeSO recipeSO, InventoryManager inventoryManager, MachinePanel machinePanel)
    {
        List<Item> items = inventoryManager.Items;
        this.machinePanel = machinePanel;
        inputs = recipeSO.Input;
        output = recipeSO.Output;
        time = recipeSO.Time;
        successRate = recipeSO.SuccessRate;

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
        successTxt.text = "Success: " + (successRate * 100).ToString() + "%";
    }

    public void SelectCrafting()
    {
        machinePanel.SelectCrafting(this);
    }

    public void SelectImage(bool select)
    {
        image.color = select ? new Color(0.2154236f, 0.6544291f, 0.9716981f, 0.5f) : new Color(0f,0f,0f,0f);
    }
}
