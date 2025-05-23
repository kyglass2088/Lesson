using UnityEngine;

public class InstanceKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            other.gameObject.GetComponent<Player>().InstanceKill();
            Debug.Log("InstanceKill trap");
        }
    }
}
