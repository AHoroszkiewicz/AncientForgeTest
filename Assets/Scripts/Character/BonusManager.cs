using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private List<Bonus> bonuses = new List<Bonus>();
    [SerializeField] private float chanceToApplyBonus = 0.25f;

    private CharacterManager characterManager;

    public void Initialize(CharacterManager characterManager)
    {
        this.characterManager = characterManager;

        foreach (var bonus in bonuses)
        {
            bonus.Initialize(this);
            int random = Random.Range(0, 100);
            if (random < chanceToApplyBonus*100)
            {
                bonus.ApplyBonus();
            }
        }
    }

    public void ApplyAll()
    {
        foreach (var bonus in bonuses)
        {
            bonus.ApplyBonus();
        }
    }
}
