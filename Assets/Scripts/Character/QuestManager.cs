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
        int completedQuests = 0;
        for (int i = 0; i < quests.Count; i++)
        {
            if (quests[i].Item == item && !quests[i].IsCompleted)
            {
                quests[i].StepQuest();
            }
            if (quests[i].IsCompleted)
            {
                completedQuests++;
                if (completedQuests == quests.Count)
                {
                    characterManager.GameManager.CharacterManager.BonusManager.ApplyAll();
                }
            }
        }
    }
}
