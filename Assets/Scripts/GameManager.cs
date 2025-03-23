using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private MachinePanelController machinePanelController;

    void Start()
    {
        inventoryManager.Initialize();
        machinePanelController.Initialize(inventoryManager);
    }
}
