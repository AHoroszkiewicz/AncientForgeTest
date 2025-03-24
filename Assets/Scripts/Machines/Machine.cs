using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{
    [SerializeField] private float defaultTimeBonus = 0f;
    [SerializeField] private float defaultSuccessBonus = 1f;
    [SerializeField] private LoadingSprite loadingSprite;

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
            float time = recipe.Time - TimeBonus();
            if (time <= 0 ) 
                time = 0.1f;
            StartCoroutine(loadingSprite.StartLoading(time));
            yield return new WaitForSeconds(time);
            float random = Random.Range(0f, 1f);
            float success = recipe.SuccessRate * SuccessBonus();
            if (random < success)
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

    private float TimeBonus()
    {
        Bonus bonus = machinePanel.MachinePanelManager.GameManager.CharacterManager.BonusManager.GetBonus(BonusEnum.TimeAmulet);
        if (bonus != null && bonus.IsApplied)
        {
            return bonus.Value;
        }

        return defaultTimeBonus;
    }

    private float SuccessBonus()
    {
        Bonus bonus = machinePanel.MachinePanelManager.GameManager.CharacterManager.BonusManager.GetBonus(BonusEnum.LuckyCharm);
        if (bonus != null && bonus.IsApplied)
        {
            return bonus.Value;
        }
        return defaultSuccessBonus;
    }
}
