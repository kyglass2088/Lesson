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

}

public class CommonTrap : BaseTrap
{
    public int TrapDamage = 10;

    public override void OnTriggerEnter(Collider other)
    {
        Player player = GetComponent<Player>();
        if (other.gameObject.CompareTag("User"))
        {
            base.AudioPosition = transform.position;
            base.OnTriggerEnter(other);

            playerData.HP -= TrapDamage;
            if (playerData.HP <= 0)
                player.PlayerDead();
            // 플레이어가 죽는 경우를 상위 클래스에 추가했는 데 Trap은 Trap의 일만 하는 것이
            // 좋다고 해서 PlayerDead() 함수를 변경하기
        }
    }
}
