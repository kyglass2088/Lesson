using System.Collections.Generic;
using UnityEngine;

public enum PlayerHitParticleType
{
    strongHit, // 많은 데미지를 받았을 때
    normalHit, // 중간 정도의 데미지를 받았을 때
    weakHit    // 약한 데미지를 받았을 때
}

public class VFXManager : MonoBehaviour
{

    public Dictionary<PlayerHitParticleType, ParticleSystem> playList;

    [SerializeField] ParticleSystem psPrefab;
    [SerializeField] ParticleSystem strongHit;
    [SerializeField] ParticleSystem NormalHit;
    [SerializeField] ParticleSystem weakgHit;

    void Start()
    {
        playList = new Dictionary<PlayerHitParticleType, ParticleSystem>();
        playList.Add(PlayerHitParticleType.strongHit, strongHit);
        playList.Add(PlayerHitParticleType.normalHit, NormalHit);
        playList.Add(PlayerHitParticleType.weakHit, weakgHit);

        BaseTrap.OnHitVFXEvent += BaseMine_OnHitEvent;


    }

    private void BaseMine_OnHitEvent(PlayerHitParticleType particle, Vector3 pos)
    {
        ParticleSystem newParticle = Instantiate(playList[particle], pos, Quaternion.identity);

        newParticle.Play();

        Destroy(newParticle.gameObject, newParticle.main.duration +
            newParticle.main.startLifetime.constantMax);
    }
    
}
