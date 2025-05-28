using UnityEngine;

public class CommonTrap : MonoBehaviour
{
    public float TrapDamage = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            other.GetComponent<Player>().CommonTrap(TrapDamage);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            TrapDamage += 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            TrapDamage -= 1.0f;
        }
    }
}
