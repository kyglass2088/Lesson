using UnityEngine;

public class InstanceKill : MonoBehaviour
{
    public PlayerData playerData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            Player player = GetComponent<Player>();
            playerData.Life--;
            other.transform.rotation = player.originalRotation;
            other.transform.position = player.originalPosition;
            playerData.HP = player.MaxPower;
            if (playerData.Life <= 0)
                player.GameOver();
        }
    }
}
