using System;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public static event Action OnGameClearEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            OnGameClearEvent?.Invoke();
        }
    }
}
