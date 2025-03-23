using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] ItemListSO itemList;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] private List<Item> items;

    public List<Item> Items => items;

    public void Initialize()
    {
        InitInventory();
    }

    private void InitInventory()
    {
        for (int i = 0; i < itemList.Items.Count; i++)
        {
            Item item = Instantiate(itemPrefab, transform).GetComponent<Item>();
            item.transform.SetParent(transform);
            int id = i + 1; // i+1 so it starts from 1 just like in the design spec
            item.Init(id, itemList.Items[i].ItemName, itemList.Items[i].ItemType, itemList.Items[i].ItemDescription, itemList.Items[i].ItemSprite);
            items.Add(item);
            switch (id)
            {
                case (int)ItemsEnum.IronOre:
                    AddItem(id, Random.Range(3,6));
                    break;
                case (int)ItemsEnum.GoldOre:
                    AddItem(id, Random.Range(1, 4));
                    break;
                case (int)ItemsEnum.FireShard:
                    AddItem(id, Random.Range(0, 3));
                    break;
                case (int)ItemsEnum.EmberDust:
                    AddItem(id, Random.Range(0, 3));
                    break;
                case (int)ItemsEnum.DragonScale:
                    AddItem(id, Random.Range(0, 2));
                    break;
            }
        }
    }

    public void AddItem(int id, int value)
    {
        items[id - 1].UpdateQuantity(value);
    }

    public void RemoveItem(int id, int value)
    {
        items[id - 1].UpdateQuantity(-value);
    }
}
