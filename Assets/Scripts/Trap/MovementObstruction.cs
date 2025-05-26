using UnityEngine;

public class MovementObstruction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            other.GetComponent<Player>().MoveDisturbance(3.0f, 3.0f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            other.GetComponent<Player>().InitializeMovement();
        }
    }
}
