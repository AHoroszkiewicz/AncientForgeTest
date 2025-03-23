using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    [SerializeField] private Image image;

    private BonusManager bonusManager;

    public void Initialize(BonusManager bonusManager)
    {
        this.bonusManager = bonusManager;
    }

    public void ApplyBonus()
    {
        image.color = Color.white;
    }
}
