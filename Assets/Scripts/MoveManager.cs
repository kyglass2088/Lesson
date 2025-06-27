using System;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public static event Action<bool> OnSineMovementEvent;
    public static event Action<bool> OnCosineMovementEvent;
    public static event Action<bool> OnTangentMovementEvent;

    public SineVerticalMovement sine;
    public TangentMovement tangent;
    public CosinMovement cosine;

    void FindIMoveable(MonoBehaviour Input)
    {
        MonoBehaviour[] components = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour comp in components)
        {
            if ((comp is IMoveable) && (Input != comp))
            {
                //Destroy(comp);
                comp.enabled = false;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            FindIMoveable(cosine);
            //OnCosineMovementEvent?.Invoke(true);
            //OnSineMovementEvent?.Invoke(false);
            //OnTangentMovementEvent?.Invoke(false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            FindIMoveable(sine);
            //OnCosineMovementEvent?.Invoke(false);
            //OnSineMovementEvent?.Invoke(true);
            //OnTangentMovementEvent?.Invoke(false);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            FindIMoveable(tangent);
            //OnCosineMovementEvent?.Invoke(false);
            //OnSineMovementEvent?.Invoke(false);
            //OnTangentMovementEvent?.Invoke(true);
        }
    }
}
