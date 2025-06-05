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
            // �÷��̾ �״� ��츦 ���� Ŭ������ �߰��ߴ� �� Trap�� Trap�� �ϸ� �ϴ� ����
            // ���ٰ� �ؼ� PlayerDead() �Լ��� �����ϱ�
        }
    }
}
