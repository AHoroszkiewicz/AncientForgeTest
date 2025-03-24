using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    [SerializeField] private ItemsEnum itemEnum;
    [SerializeField] private string itemName;
    [SerializeField] private ItemTypeEnum itemType;
    [SerializeField] private string itemDescription;
    [SerializeField] private Sprite itemSprite;

    public ItemsEnum ItemEnum => itemEnum;
    public string ItemName => itemName;
    public ItemTypeEnum ItemType => itemType;
    public string ItemDescription => itemDescription;
    public Sprite ItemSprite => itemSprite;
}
