using System;
using UnityEngine;

public class InstanceKill : BaseTrap
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            base.AudioPosition = transform.position;
            base.OnTriggerEnter(other);
            playerData.HP = 0;
        }
    }
}
