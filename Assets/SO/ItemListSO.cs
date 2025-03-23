using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemListSO", menuName = "Scriptable Objects/ItemListSO")]
public class ItemListSO : ScriptableObject
{
    [SerializeField] private List<ItemSO> items;

    public List<ItemSO> Items => items;
}
