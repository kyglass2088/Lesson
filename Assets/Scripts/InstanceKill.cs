using System;
using UnityEngine;

public class InstanceKill : MonoBehaviour
{
    public static event Action<Vector3, AudioType> OnInstanceKillTrapSoundEvent;

    public PlayerData playerData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            Player player = GetComponent<Player>();
            OnInstanceKillTrapSoundEvent?.Invoke(transform.position, AudioType.Over);
            playerData.Life--;
            other.transform.rotation = player.originalRotation;
            other.transform.position = player.originalPosition;
            playerData.HP = player.MaxPower;
            if (playerData.Life <= 0)
                player.GameOver();
        }
    }
}
