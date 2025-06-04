using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public static event Action OnGameClearEvent;
    public static event Action<Vector3, AudioType> OnGameClearSoundEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            OnGameClearEvent?.Invoke();
            OnGameClearSoundEvent?.Invoke(transform.position, AudioType.Clear);
        }
    }
}
