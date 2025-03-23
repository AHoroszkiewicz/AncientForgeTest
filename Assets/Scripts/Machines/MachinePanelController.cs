using System.Collections.Generic;
using UnityEngine;

public class MachinePanelController : MonoBehaviour
{

    [SerializeField] private List<MachinePanel> machinePanels = new List<MachinePanel>();

    private InventoryManager inventoryManager;

    public void Initialize(InventoryManager inventoryManager)
    {
        this.inventoryManager = inventoryManager;
        foreach (MachinePanel machinePanel in machinePanels)
        {
            machinePanel.Initialize(this.inventoryManager);
        }
    }

    public void ShowPanel(int id)
    {
        for (int i = 0; i < machinePanels.Count; i++)
        {
            if (i == id)
            {
                machinePanels[i].gameObject.SetActive(true);
            }
            else
            {
                machinePanels[i].gameObject.SetActive(false);
            }
        }
    }
}
