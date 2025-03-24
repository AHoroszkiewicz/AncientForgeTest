using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private BonusSO bonusSO;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private HoverDescription hoverDescription;

    private BonusManager bonusManager;
    private bool isApplied = false;
    private string bonusName;
    private string bonusDescription;

    public BonusEnum BonusType => bonusSO.BonusType;
    public float Value => bonusSO.Value;
    public bool IsApplied => isApplied;

    public void Initialize(BonusManager bonusManager)
    {
        this.bonusManager = bonusManager;
        bonusName = bonusSO.BonusName;
        bonusDescription = bonusSO.BonusDescription;
        hoverDescription.Initialize(bonusName, bonusDescription);
    }

    public void ApplyBonus()
    {
        if (isApplied) return;
        isApplied = true;
        image.color = Color.white;
        particle.Play();
    }
}
