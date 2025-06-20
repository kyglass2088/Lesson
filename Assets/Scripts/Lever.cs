using System;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public static event Action OnLeverEvent;

    public GameObject LeverHandle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            transform.rotation = Quaternion.Euler(0, 0, -75);
            OnLeverEvent?.Invoke();
        }
    }
}
