using System.Collections.Generic;
using UnityEngine;

public class MachinePanelController : MonoBehaviour
{
    [SerializeField] private List<MachinePanel> machinePanels = new List<MachinePanel>();

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
