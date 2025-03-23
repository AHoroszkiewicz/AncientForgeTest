using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private MachinePanelManager machinePanelController;
    [SerializeField] private CharacterManager characterManager;

    public InventoryManager InventoryManager => inventoryManager;
    public MachinePanelManager MachinePanelController => machinePanelController;
    public CharacterManager CharacterManager => characterManager;

    void Start()
    {
        inventoryManager.Initialize(this);
        machinePanelController.Initialize(this);
        characterManager.Initialize(this);
    }
}
