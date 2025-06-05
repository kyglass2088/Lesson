using System;
using UnityEngine;

public class HiddenTrap : BaseTrap
{
    public static event Action<Vector3, AudioType> OnHiddenTrapSoundEvent;

    Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = false;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("User"))
    //        renderer.enabled = true;
    //    else
    //        renderer.enabled = false;
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            renderer.enabled = true;
            base.AudioPosition = transform.position;
            base.OnTriggerEnter(other);
        }
        else
            renderer.enabled = false;
    }

}
