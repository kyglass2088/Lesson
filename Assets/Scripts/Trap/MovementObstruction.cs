using UnityEngine;

public class MovementObstruction : BaseTrap
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            playerData.MoveSpeed -= 3.0f;
            playerData.JumpForce -= 3.0f;
            base.AudioPosition = transform.position;
            base.OnTriggerEnter(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            Player player = GetComponent<Player>();
            playerData.MoveSpeed = playerData.OriginalMoveSpeed;
            playerData.JumpForce = playerData.OriginalJumpSpeed;
        }
    }
}
