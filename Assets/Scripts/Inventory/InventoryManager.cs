using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    [SerializeField] private float idleResourceTime = 5f;
    [SerializeField] private LoadingSprite loadingSprite;

    private GameManager gameManager;

    public List<Item> Items => items;

    public void Initialize(GameManager gameManager)
    {
        this.gameManager = gameManager;
        InitInventory();
    }

    private void InitInventory()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            item.Init();
            switch (item.ItemEnum)
            {
                case ItemsEnum.IronOre:
                    AddItem(Random.Range(3, 6), itemEnum: ItemsEnum.IronOre);
                    break;
                case ItemsEnum.GoldOre:
                    AddItem(Random.Range(1, 4), itemEnum: ItemsEnum.GoldOre);
                    break;
                case ItemsEnum.FireShard:
                    AddItem(Random.Range(0, 3), itemEnum: ItemsEnum.FireShard);
                    break;
                case ItemsEnum.EmberDust:
                    AddItem(Random.Range(0, 3), itemEnum: ItemsEnum.EmberDust);
                    break;
                case ItemsEnum.DragonScale:
                    AddItem(Random.Range(0, 2), itemEnum: ItemsEnum.DragonScale);
                    break;
            }
        }
        StartCoroutine(IdleResources());
    }

    public void AddItem(int value, ItemsEnum itemEnum = ItemsEnum.None, int id = -1)
    {
        gameManager.CharacterManager.QuestManager.CheckQuests(itemEnum);
        if (id != -1)
        {
            items[id - 1].UpdateQuantity(value);
            return;
        }
        else if (itemEnum != ItemsEnum.None)
        {
            items[(int)itemEnum - 1].UpdateQuantity(value);
            return;
        }
    }

    public void RemoveItem(int id, int value)
    {
        items[id - 1].UpdateQuantity(-value);
    }

    private IEnumerator IdleResources()
    {
        while (true)
        {
            StartCoroutine(loadingSprite.StartLoading(idleResourceTime));
            yield return new WaitForSeconds(idleResourceTime);
            int randomItem = Random.Range(1, 6);
            AddItem(1, id: randomItem);
        }
    }

    public void Cheat()
    {
        foreach (Item item in items)
        {
            if (item.Type == ItemTypeEnum.Resource)
            {
                AddItem(10, itemEnum: item.ItemEnum);
            }
        }
    }
}
