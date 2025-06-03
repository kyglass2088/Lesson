using UnityEngine;

public class MovementObstruction : MonoBehaviour
{
    public PlayerData playerData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            playerData.MoveSpeed -= 3.0f;
            playerData.JumpForce -= 3.0f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            Player player = GetComponent<Player>();
            playerData.MoveSpeed = player.originalMoveSpeed;
            playerData.JumpForce = player.originalJumpForce;
        }
    }
}
