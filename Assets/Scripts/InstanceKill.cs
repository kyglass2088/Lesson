using System;
using UnityEngine;

public class InstanceKill : BaseTrap
{

    private void OnTriggerEnter(Collider other)
    {
        Player player = GetComponent<Player>();
        if (other.gameObject.CompareTag("User"))
        {
            base.AudioPosition = transform.position;
            base.OnTriggerEnter(other);
            player.PlayerDead();
        }
    }
}
