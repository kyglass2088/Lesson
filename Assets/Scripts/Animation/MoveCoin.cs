using System;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCoin : MonoBehaviour
{
    public static event Action<Vector3, ItemParticle> OnShinyGetItem;
    public static event Action<Vector3, ItemAudioType> OnItemSpinEvent;
    public static event Action OnItemAnimEvent;

    public ItemAudioType ItemAudioType;
    public ItemParticle ItemParticle;

    public GameObject gameObject;

    int TripCount = 0;

    public void PlayerGetItem()
    {
        OnShinyGetItem?.Invoke(transform.position, ItemParticle);
        // 사라질 때 효과음 추가
    }

    public virtual void ItemSpinEnd()
    {
        OnItemSpinEvent?.Invoke(transform.position, ItemAudioType);
        Debug.Log("ItemSpinEnd");
    }

    public void ItemAnimEnd()
    {
        OnItemAnimEvent?.Invoke();
        Debug.Log("ItemAnimEnd");
    }

    public void ItemDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            PlayerGetItem();
            // 플레이어의 돈을 추가하는 스크립트 추가
        }
    }
}
