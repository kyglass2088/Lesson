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
            // �÷��̾ �״� ��츦 ���� Ŭ������ �߰��ߴ� �� Trap�� Trap�� �ϸ� �ϴ� ����
            // ���ٰ� �ؼ� PlayerDead() �Լ��� �����ϱ�
        }
    }
}
