using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int Life = 5;
    public float HP = 100;
    public float JumpForce = 5f;
    public float MoveSpeed = 5;
    public float bounceForce = 10f;
}
