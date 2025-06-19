using UnityEngine;

[CreateAssetMenu(fileName = "StageLevelSO", menuName = "Scriptable Objects/StageLevelSO")]
public class StageLevelSO : ScriptableObject
{
    public int TrapAmount;
    public int CollectibleNumber;

    public float DamageMagnification;
    public float TrapSizeMagnification;
    public float JumpForce;

}
