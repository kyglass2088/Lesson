using System;
using UnityEngine;

public enum ItemParticle
{
    shiny,
    explosion,
}

public class BaseItem : MonoBehaviour
{
    public static event Action<Vector3, ItemParticle> OnShinyGetItem;
    public static event Action<Vector3, ItemAudioType> OnItemSpinEvent;
    public static event Action OnItemAnimEvent;

    public ItemAudioType ItemAudioType;
    public ItemParticle ItemParticle;

    protected virtual void ItemSpinEnd()
    {
        OnItemSpinEvent?.Invoke(transform.position, ItemAudioType);
        Debug.Log("ItemSpinEnd");
    }

    public void PlayerGetItem()
    {
        OnShinyGetItem?.Invoke(transform.position, ItemParticle);
        // 사라질 때 효과음 추가
    }

    public void ItemAnimEnd()
    {
        OnItemAnimEvent?.Invoke();
        Debug.Log("ItemAnimEnd");
    }
}

public class NewCoin : BaseItem
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("User"))
        {
            base.PlayerGetItem();
            // 플레이어의 돈을 추가하는 스크립트 추가
        }
    }
}
