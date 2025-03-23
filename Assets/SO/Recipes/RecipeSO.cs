using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeSO", menuName = "Scriptable Objects/RecipeSO")]
public class RecipeSO : ScriptableObject
{
    [SerializeField] private List<ItemsEnum> input = new List<ItemsEnum>();
    [SerializeField] private float time;
    [SerializeField] private float successRate;
    [SerializeField] private ItemsEnum output;

    public List<ItemsEnum> Input => input;
    public float Time => time;
    public float SuccessRate => successRate;
    public ItemsEnum Output => output;
}
