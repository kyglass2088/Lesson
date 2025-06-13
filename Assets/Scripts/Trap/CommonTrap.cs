using System;
using System.Security.Cryptography;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    public static event Action<Vector3, AudioType> OnSoundEvent;
    public static event Action<int> OnDamageTrapCollisionEvent;
    public AudioType myType;

    public PlayerData playerData;

    protected Vector3 AudioPosition;

    public virtual void OnTriggerEnter(Collider other)
    {
        OnSoundEvent?.Invoke(AudioPosition, myType);
    }

    public virtual void DamageTrapCollision(int TrapDamage)
    {
        OnDamageTrapCollisionEvent?.Invoke(TrapDamage);
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

            DamageTrapCollision(TrapDamage);
            // �÷��̾ �״� ��츦 ���� Ŭ������ �߰��ߴ� �� Trap�� Trap�� �ϸ� �ϴ� ����
            // ���ٰ� �ؼ� PlayerDead() �Լ��� �����ϱ�
        }
    }
}
