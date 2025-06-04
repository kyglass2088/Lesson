using System;
using UnityEngine;

public class CommonTrap : MonoBehaviour
{
    public static event Action<Vector3, AudioType> OnCommonTrapSoundEvent;

    public PlayerData playerData;
    public float TrapDamage = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            Player player = GetComponent<Player>();
            OnCommonTrapSoundEvent?.Invoke(transform.position, AudioType.Hit);
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
