using System;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    public StageLevelSO stageLevelSO;
    public StageManager stageManager;
    public static event Action<Vector3, playerAudioType> OnSoundEvent;
    public static event Action<float> OnDamageTrapCollisionEvent;
    public static event Action<PlayerHitParticleType, Vector3> OnHitVFXEvent;
    public playerAudioType myType;

    public PlayerData playerData;

    protected Vector3 AudioPosition;

    private void Start()
    {
        //stageLevelSO = stageManager.CurrentStageLevel;
        transform.localScale *= stageLevelSO.TrapSizeMagnification;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        OnSoundEvent?.Invoke(AudioPosition, myType);
    }

    public void DamageTrapCollision(float TrapDamage, Vector3 position)
    {
        OnDamageTrapCollisionEvent?.Invoke(TrapDamage);
        if (TrapDamage > (playerData.MaxHp / 2))
            OnHitVFXEvent?.Invoke(PlayerHitParticleType.strongHit, position);
        else if (TrapDamage > (playerData.MaxHp / 10))
            OnHitVFXEvent?.Invoke(PlayerHitParticleType.normalHit, position);
        else
            OnHitVFXEvent?.Invoke(PlayerHitParticleType.weakHit, position);

    }
}
