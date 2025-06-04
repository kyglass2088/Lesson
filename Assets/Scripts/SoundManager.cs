using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    Hit,
    Over,
    Clear,
    Item,
    Jump,
    Run
}

public class SoundManager : MonoBehaviour
{                   //Head      ����//
                    //key        value
    public Dictionary<AudioType, AudioClip> playList;


    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip over;
    [SerializeField] AudioClip clear;
    [SerializeField] AudioClip item;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip run;

    private void Start()
    {
        playList = new Dictionary<AudioType, AudioClip>();
        playList.Add(AudioType.Hit, hit);
        playList.Add(AudioType.Over, over);
        playList.Add(AudioType.Clear, clear);
        playList.Add(AudioType.Item, item);
        playList.Add(AudioType.Jump, jump);
        playList.Add(AudioType.Run, run);

        HiddenTrap.OnHiddenTrapSoundEvent += PlaySoundEvent;
        InstanceKill.OnInstanceKillTrapSoundEvent += PlaySoundEvent;
        CommonTrap.OnCommonTrapSoundEvent += PlaySoundEvent;
        Goal.OnGameClearSoundEvent += PlaySoundEvent;
        Player.OnRunSoundEvent += PlaySoundEvent;
        Player.OnJumpSoundEvent += PlaySoundEvent;
    }

    public void PlaySoundEvent(Vector3 SoundPosition, AudioType audioClip)
    {
        AudioSource.PlayClipAtPoint(playList[audioClip], SoundPosition);
    }

    public void PlayOneList(AudioType myType)
    {
        AudioClip clip = playList[myType];
        AudioSource.PlayClipAtPoint(clip, transform.position);
        Debug.Log("audio clip name" + clip.name);
    }
}
