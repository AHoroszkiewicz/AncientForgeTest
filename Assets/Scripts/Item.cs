using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    //Serialized Fields just for testing purposes
    [SerializeField] private int id;
    [SerializeField] private string itemName;
    [SerializeField] private ItemType type;
    [SerializeField] private string description;
    [SerializeField] private int quantity;

    [SerializeField] private Image itemImage;

    public void Init(int id, string itemName, ItemType itemType, string desc, Sprite sprite, int quantity = 0)
    {
        this.id = id;
        this.itemName = itemName;
        type = itemType;
        description = desc;
        itemImage.sprite = sprite;
        this.quantity = quantity;
    }
}
