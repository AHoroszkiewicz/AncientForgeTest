using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] ItemListSO itemList;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] private List<Item> items;

    private void Start()
    {
        for (int i = 0; i < itemList.Items.Count; i++)
        {
            Item item = Instantiate(itemPrefab, transform).GetComponent<Item>();
            item.transform.SetParent(transform);
            item.Init(i+1, itemList.Items[i].ItemName, itemList.Items[i].ItemType, itemList.Items[i].ItemDescription, itemList.Items[i].ItemSprite); // i+1 so it starts from 1 just like in the design spec
            items.Add(item);
        }
    }
}
