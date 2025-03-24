using System.Collections.Generic;
using UnityEngine;

public class MachinePanelManager : MonoBehaviour
{
    [SerializeField] private List<MachinePanel> machinePanels = new List<MachinePanel>();

    private GameManager gameManager;

    public GameManager GameManager => gameManager;

    public void Initialize(GameManager gameManager)
    {
        this.gameManager = gameManager;
        foreach (MachinePanel machinePanel in machinePanels)
        {
            machinePanel.Initialize(this);
        }
    }

    public void ShowPanel(int id)
    {
        for (int i = 0; i < machinePanels.Count; i++)
        {
            if (i == id)
            {
                machinePanels[i].Show();
            }
            else
            {
                machinePanels[i].Hide();
            }
        }
    }

    public void UnlockPanel(int id)
    {
        machinePanels[id].Unlock();
    }
}
