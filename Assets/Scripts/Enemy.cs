using UnityEngine;

public class Enemy : MonoBehaviour
{
    EventBinding<PlayerEvent> playerEventBinding;

    private void OnEnable()
    {
        playerEventBinding = new EventBinding<PlayerEvent>(HandleEnemyEvent);
        EventBus<PlayerEvent>.Register(playerEventBinding);
    }

    private void HandleEnemyEvent(PlayerEvent @event)
    {
        Debug.Log("HandleEnemyEvent  @event.health " + @event.health);
        Debug.Log("HandleEnemyEvent  @event.mana " + @event.mana);
    }

    int EnemyMethodWithParam(int number)
    {
        Debug.Log("EnemyMethodWithParam! " + number);

        return number * number;
    }

    void EnemyAction()
    {
        Debug.Log("EnemyAction!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        EventBus<PlayerEvent>.Raise(new PlayerEvent
        {
            health = 0,
            mana = 0,
            myAction = EnemyAction,
            myFunc = EnemyMethodWithParam
        });
    }
}
