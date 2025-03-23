using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private List<MachinePanel> machinePanels = new List<MachinePanel>();

    void Start()
    {
        inventoryManager.Initialize();
        foreach (MachinePanel machinePanel in machinePanels)
        {
            machinePanel.Initialize();
        }
    }
}
