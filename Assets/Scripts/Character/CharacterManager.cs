using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private QuestManager questManager;
    [SerializeField] private BonusManager bonusManager;

    private GameManager gameManager;

    public GameManager GameManager => gameManager;
    public QuestManager QuestManager => questManager;
    public BonusManager BonusManager => bonusManager;

    public void Initialize(GameManager gameManager)
    {
        this.gameManager = gameManager;
        questManager.Initialize(this);
        bonusManager.Initialize(this);
    }
}
