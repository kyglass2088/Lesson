using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float MaxHp = 100;
    public float OriginalMoveSpeed = 5f;
    public float OriginalJumpSpeed = 5f; 

    public int Life = 5;
    public float HP = 100;
    public float JumpForce = 5f;
    public float MoveSpeed = 5;
    public float bounceForce = 10f;
}
