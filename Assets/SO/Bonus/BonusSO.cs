using UnityEngine;

[CreateAssetMenu(fileName = "BonusSO", menuName = "Scriptable Objects/BonusSO")]
public class BonusSO : ScriptableObject
{
    [SerializeField] private BonusEnum bonusType;
    [SerializeField] private float value;
    [SerializeField] private string bonusName;
    [SerializeField] private string bonusDescription;

    public BonusEnum BonusType => bonusType;
    public float Value => value;
    public string BonusName => bonusName;
    public string BonusDescription => bonusDescription;
}
