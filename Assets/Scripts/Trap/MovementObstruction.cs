using UnityEngine;

public class MovementObstruction : BaseTrap
{
    public float deceleration;
    public float lowerJump;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            if (playerData.MoveSpeed - deceleration > 0)
                playerData.MoveSpeed -= deceleration;
            if (playerData.JumpForce - lowerJump > 0)
                playerData.JumpForce -= lowerJump;

            base.AudioPosition = transform.position;
            base.OnTriggerEnter(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            playerData.MoveSpeed = playerData.OriginalMoveSpeed;
            playerData.JumpForce = playerData.OriginalJumpSpeed;
        }
    }
}
