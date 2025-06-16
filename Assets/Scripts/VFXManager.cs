using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public enum ParticleType
{
    strongHit, // 많은 데미지를 받았을 때
    normalHit, // 중간 정도의 데미지를 받았을 때
    weakHit    // 약한 데미지를 받았을 때
}

public class VFXManager : MonoBehaviour
{

    public Dictionary<ParticleType, ParticleSystem> playList;

    [SerializeField] ParticleSystem psPrefab;
    [SerializeField] ParticleSystem strongHit;
    [SerializeField] ParticleSystem NormalHit;
    [SerializeField] ParticleSystem weakgHit;

    void Start()
    {
        playList = new Dictionary<ParticleType, ParticleSystem>();
        playList.Add(ParticleType.strongHit, strongHit);
        playList.Add(ParticleType.normalHit, NormalHit);
        playList.Add(ParticleType.weakHit, weakgHit);

        BaseTrap.OnHitVFXEvent += BaseMine_OnHitEvent;


    }

    private void BaseMine_OnHitEvent(ParticleType particle, Vector3 pos)
    {
        ParticleSystem newParticle = Instantiate(playList[particle], pos, Quaternion.identity);

        newParticle.Play();

        Destroy(newParticle.gameObject, newParticle.main.duration +
            newParticle.main.startLifetime.constantMax);
    }
    
}
