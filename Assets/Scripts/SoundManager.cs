using System.Collections.Generic;
using UnityEngine;

public enum playerAudioType
{
    Hit,
    Over,
    Clear,
    Jump,
    Run,
}

public enum ItemAudioType
{
    useItem,
    getItem,
    spinItem
}

public class SoundManager : MonoBehaviour
{                   //Head      ¼­¼ú//
                    //key        value
    public Dictionary<playerAudioType, AudioClip> playList;
    public Dictionary<ItemAudioType, AudioClip> itemList;

    [Header("PlayerAudioType")]
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip hit;
    [SerializeField] AudioClip over;
    [SerializeField] AudioClip clear;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip run;

    [Header("ItemAudioType")]
    [SerializeField] AudioClip useItem;
    [SerializeField] AudioClip getItem;
    [SerializeField] AudioClip spinItem;

    private void Start()
    {
        playList = new Dictionary<playerAudioType, AudioClip>();
        itemList = new Dictionary<ItemAudioType, AudioClip>();

        playList.Add(playerAudioType.Hit, hit);
        playList.Add(playerAudioType.Over, over);
        playList.Add(playerAudioType.Clear, clear);
        playList.Add(playerAudioType.Jump, jump);
        playList.Add(playerAudioType.Run, run);

        itemList.Add(ItemAudioType.getItem, getItem);
        itemList.Add(ItemAudioType.useItem, useItem);
        itemList.Add(ItemAudioType.spinItem, spinItem);

        NewCoin.OnItemSpinEvent += ItemSpinEvent;
        BaseTrap.OnSoundEvent += PlaySoundEvent;
    }

    public void ItemSpinEvent(Vector3 SoundPosition, ItemAudioType audioClip)
    {
        AudioSource.PlayClipAtPoint(itemList[audioClip], SoundPosition);
    }

    public void PlaySoundEvent(Vector3 SoundPosition, playerAudioType audioClip)
    {
        AudioSource.PlayClipAtPoint(playList[audioClip], SoundPosition);
    }

    public void PlayOneList(playerAudioType myType)
    {
        AudioClip clip = playList[myType];
        AudioSource.PlayClipAtPoint(clip, transform.position);
        Debug.Log("audio clip name" + clip.name);
    }
}
