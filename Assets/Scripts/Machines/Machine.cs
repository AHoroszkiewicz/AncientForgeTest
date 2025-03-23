using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    private Queue<Recipe> craftingQueue = new Queue<Recipe>();
    private bool isCrafting = false;
    private MachinePanel machinePanel;

    public void Initialize(MachinePanel machinePanel)
    {
        this.machinePanel = machinePanel;
    }

    public void Craft(Recipe recipe)
    {
        craftingQueue.Enqueue(recipe);
        if (!isCrafting)
        {
            isCrafting = true;
            StartCoroutine(Crafting());
        }
    }

    private IEnumerator Crafting()
    {
        while (craftingQueue.Count > 0)
        {
            var recipe = craftingQueue.Peek();
            yield return new WaitForSeconds(recipe.Time);
            if (Random.Range(0, 1) < recipe.SuccessRate)
            {
                machinePanel.MachinePanelManager.GameManager.InventoryManager.AddItem((int)craftingQueue.Dequeue().Output, 1);
            }
            else
            {
                Debug.Log("Crafting failed"); //TODO
            }
        }
        isCrafting = false;
    }
}
