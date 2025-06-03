using UnityEngine;

public class CommonTrap : MonoBehaviour
{
    public PlayerData playerData;
    public float TrapDamage = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            Player player = GetComponent<Player>();
            playerData.HP -= TrapDamage;
            if (playerData.HP <= 0)
            {
                playerData.HP = player.MaxPower;
                other.transform.rotation = player.originalRotation;
                other.transform.position = player.originalPosition;
                playerData.Life--;
                if (playerData.Life <= 0)
                    player.GameOver();
            }
        }
    }
}
