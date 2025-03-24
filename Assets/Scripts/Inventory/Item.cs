using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private ItemSO itemSO;
    [SerializeField] private HoverDescription hoverDescription;

    //Serialized Fields just for testing purposes
    [SerializeField] private ItemsEnum itemEnum;
    [SerializeField] private string itemName;
    [SerializeField] private ItemTypeEnum type;
    [SerializeField] private string description;
    [SerializeField] private int quantity;

    public ItemsEnum ItemEnum => itemEnum;
    public string ItemName => itemName;
    public ItemTypeEnum Type => type;
    public string Description => description;
    public int Quantity => quantity;
    public Image ItemImage => itemImage;

    public void Init()
    {
        itemName = itemSO.ItemName;
        type = itemSO.ItemType;
        description = itemSO.ItemDescription;
        itemImage.sprite = itemSO.ItemSprite;
        itemEnum = itemSO.ItemEnum;
        hoverDescription.Initialize(itemName, description);
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
        if (quantity > 999)
        {
            quantity = 999;
        }
        quantityText.text = quantity.ToString();
    }
}
