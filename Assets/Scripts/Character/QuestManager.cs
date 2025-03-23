using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private List<Quest> quests = new List<Quest>();

    private CharacterManager characterManager;

    public CharacterManager CharacterManager => characterManager;

    public void Initialize(CharacterManager characterManager)
    {
        this.characterManager = characterManager;
        foreach (Quest quest in quests)
        {
            quest.Initialize(this);
        }
    }

    public void CheckQuests(ItemsEnum item)
    {
        foreach (Quest quest in quests)
        {
            if (quest.Item == item && !quest.IsCompleted)
            {
                quest.StepQuest();
            }
        }
    }
}
