using UnityEngine;

public class MovementObstruction : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("User"))
        {
            collision.gameObject.GetComponent<Player>().MoveDisturbance(3.0f, 3.0f);
        }
    }
}
