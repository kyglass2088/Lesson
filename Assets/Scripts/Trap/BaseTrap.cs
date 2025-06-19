using System;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    public StageLevelSO stageLevelSO;
    public static event Action<Vector3, AudioType> OnSoundEvent;
    public static event Action<float> OnDamageTrapCollisionEvent;
    public static event Action<ParticleType, Vector3> OnHitVFXEvent;
    public AudioType myType;

    public PlayerData playerData;

    protected Vector3 AudioPosition;

    //private void Start()
    //{
    //    transform.localScale *= stageLevelSO.TrapSizeMagnification;
    //}

    public virtual void OnTriggerEnter(Collider other)
    {
        OnSoundEvent?.Invoke(AudioPosition, myType);
    }

    public void DamageTrapCollision(float TrapDamage, Vector3 position)
    {
        OnDamageTrapCollisionEvent?.Invoke(TrapDamage);
        if (TrapDamage > (playerData.MaxHp / 2))
            OnHitVFXEvent?.Invoke(ParticleType.strongHit, position);
        else if (TrapDamage > (playerData.MaxHp / 10))
            OnHitVFXEvent?.Invoke(ParticleType.normalHit, position);
        else
            OnHitVFXEvent?.Invoke(ParticleType.weakHit, position);

    }

}
