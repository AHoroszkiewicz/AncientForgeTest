using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private QuestSO questSO;
    [SerializeField] private TextMeshProUGUI questNameTxt;
    [SerializeField] private ParticleSystem successParticle;

    private bool isCompleted;
    private string questName;
    private string questDescription;
    private ItemsEnum item;
    private int value;
    private MachinesEnum unlockedMachine;
    private QuestManager questManager;

    public bool IsCompleted => isCompleted;
    public string QuestName => questName;
    public string QuestDescription => questDescription;
    public ItemsEnum Item => item;
    public int Value => value;
    public MachinesEnum UnlockedMachine => unlockedMachine;

    public void Initialize(QuestManager questManager)
    {
        questName = questSO.QuestName;
        questDescription = questSO.QuestDescription;
        item = questSO.Item;
        value = questSO.Value;
        unlockedMachine = questSO.UnlockedMachine;
        this.questManager = questManager;

        questNameTxt.text = questName;
    }

    public void StepQuest()
    {
        value--;
        if (value <= 0)
        {
            isCompleted = true;
            FinishQuest();
        }
    }

    private void FinishQuest()
    {
        questNameTxt.color = Color.green;
        questManager.CharacterManager.GameManager.MachinePanelController.UnlockPanel((int)unlockedMachine - 1);
        successParticle.Play();
    }
}
