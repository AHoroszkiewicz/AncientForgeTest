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

    public int Id => id;
    public string ItemName => itemName;
    public ItemTypeEnum Type => type;
    public string Description => description;
    public int Quantity => quantity;
    public Image ItemImage => itemImage;

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
        if (quantity < 0)
        {
            quantity = 0;
        }
        quantityText.text = quantity.ToString();
    }
}
