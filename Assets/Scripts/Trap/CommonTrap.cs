using System;
using System.Security.Cryptography;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    public static event Action<Vector3, AudioType> OnSoundEvent;
    public AudioType myType;

    public PlayerData playerData;

    protected Vector3 AudioPosition;

    public virtual void OnTriggerEnter(Collider other)
    {
        OnSoundEvent?.Invoke(AudioPosition, myType);
    }

    public virtual void PlayerDead(Transform PlayerTransform)
    {
        Player player = GetComponent<Player>();
        playerData.Life--;
        PlayerTransform.rotation = player.originalRotation;
        PlayerTransform.position = player.originalPosition;
        playerData.HP = player.MaxPower;
        if (playerData.Life <= 0)
            player.GameOver();
    }
}

public class CommonTrap : BaseTrap
{
    public PlayerData playerData;
    public float TrapDamage = 10.0f;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            base.AudioPosition = transform.position;
            base.OnTriggerEnter(other);

            playerData.HP -= TrapDamage;
            if (playerData.HP <= 0)
                base.PlayerDead(other.transform);
            // 플레이어가 죽는 경우를 상위 클래스에 추가했는 데 Trap은 Trap의 일만 하는 것이
            // 좋다고 해서 PlayerDead() 함수를 변경하기
        }
    }
}
