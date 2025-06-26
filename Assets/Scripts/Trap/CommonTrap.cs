using System.Security.Cryptography;
using UnityEngine;

public class CommonTrap : BaseTrap
{
    public int TrapDamage = 30;

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            base.AudioPosition = transform.position;
            base.OnTriggerEnter(other);

            DamageTrapCollision(TrapDamage * currentStageLevelSO.DamageMagnification, other.transform.position);
            // 플레이어가 죽는 경우를 상위 클래스에 추가했는 데 Trap은 Trap의 일만 하는 것이
            // 좋다고 해서 PlayerDead() 함수를 변경하기
        }
    }
}
