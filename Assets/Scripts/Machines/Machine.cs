using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{
    [SerializeField] private float defaultTimeBonus = 0f;
    [SerializeField] private float defaultSuccessBonus = 1f;
    [SerializeField] private LoadingSprite loadingSprite;
    [SerializeField] private ParticleSystem successParticle;
    [SerializeField] private ParticleSystem failureParticle;
    [SerializeField] private HoverDescription hoverDescription;
    [SerializeField] private string machineName;
    [SerializeField] private string machineDesc;


    private Queue<Recipe> craftingQueue = new Queue<Recipe>();
    private bool isCrafting = false;
    private MachinePanel machinePanel;

    public void Initialize(MachinePanel machinePanel)
    {
        this.machinePanel = machinePanel;
        hoverDescription.Initialize(machineName, machineDesc);
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
                successParticle.Play();
                machinePanel.MachinePanelManager.GameManager.InventoryManager.AddItem(1, itemEnum: craftingQueue.Dequeue().Output);
            }
            else
            {
                AudioManager.Instance.PlayFailSound();
                failureParticle.Play();
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
