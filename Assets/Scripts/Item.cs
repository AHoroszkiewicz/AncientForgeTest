using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //Serialized Fields just for testing purposes
    [SerializeField] private int id;
    [SerializeField] private string itemName;
    [SerializeField] private ItemTypeEnum type;
    [SerializeField] private string description;
    [SerializeField] private int quantity;

    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI quantityText;

    public void Init(int id, string itemName, ItemTypeEnum itemType, string desc, Sprite sprite, int quantity = 0)
    {
        this.id = id;
        this.itemName = itemName;
        type = itemType;
        description = desc;
        itemImage.sprite = sprite;
        SetQuantity(quantity);
    }

    public void SetQuantity(int value)
    {
        quantity = value;
        quantityText.text = quantity.ToString();
    }

    public void UpdateQuantity(int value)
    {
        quantity += value;
        quantityText.text = quantity.ToString();
    }
}
