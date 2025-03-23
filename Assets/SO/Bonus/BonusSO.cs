using UnityEngine;

[CreateAssetMenu(fileName = "BonusSO", menuName = "Scriptable Objects/BonusSO")]
public class BonusSO : ScriptableObject
{
    [SerializeField] private BonusEnum bonusType;
    [SerializeField] private float value;

    public BonusEnum BonusType => bonusType;
    public float Value => value;
}
