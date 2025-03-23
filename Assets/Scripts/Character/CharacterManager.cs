using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private QuestManager questManager;

    private GameManager gameManager;

    public GameManager GameManager => gameManager;
    public QuestManager QuestManager => questManager;

    public void Initialize(GameManager gameManager)
    {
        this.gameManager = gameManager;
        questManager.Initialize(this);
    }
}
