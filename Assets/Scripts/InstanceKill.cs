using System;
using UnityEngine;

public class InstanceKill : BaseTrap
{

    public PlayerData playerData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            base.AudioPosition = transform.position;
            base.OnTriggerEnter(other);
            base.PlayerDead(other.transform);
        }
    }
}
