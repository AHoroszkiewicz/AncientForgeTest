using UnityEngine;

[CreateAssetMenu(fileName = "QuestSO", menuName = "Scriptable Objects/QuestSO")]
public class QuestSO : ScriptableObject
{
    [SerializeField] private string questName;
    [SerializeField] private string questDescription;
    [SerializeField] private ItemsEnum item;
    [SerializeField] private int value;
    [SerializeField] private MachinesEnum unlockedMachine;

    public string QuestName => questName;
    public string QuestDescription => questDescription;
    public ItemsEnum Item => item;
    public int Value => value;
    public MachinesEnum UnlockedMachine => unlockedMachine;
}
