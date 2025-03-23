using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private ItemType itemType;
    [SerializeField] private string itemDescription;
    [SerializeField] private Sprite itemSprite;

    public string ItemName => itemName;
    public ItemType ItemType => itemType;
    public string ItemDescription => itemDescription;
    public Sprite ItemSprite => itemSprite;
}
