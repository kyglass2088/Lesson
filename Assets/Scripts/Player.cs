using NUnit.Framework.Internal;
using System;
using UnityEngine;

public class Enemy
{
    public void KillPlayer()
    {
        EventBus<TestEvent>.Raise(new TestEvent());

        EventBus<PlayerEvent>.Raise(new PlayerEvent
        {
            health = 0,
            mana = 0
        });

    }

}

public class Player : MonoBehaviour
{
    EventBinding<TestEvent> testEventBinding;
    EventBinding<PlayerEvent> playerEventBinding;

    private void OnEnable()
    {
        testEventBinding = new EventBinding<TestEvent>(HandleTestEvent);
        EventBus<TestEvent>.Register(testEventBinding);

        playerEventBinding = new EventBinding<PlayerEvent>(HandlePlayerEvent);
        EventBus<TestEvent>.Register(testEventBinding);
    }

    void SlowDown()
    {

    }
    void SpeedUp()
    {

    }


    private void HandlePlayerEvent(PlayerEvent @event)
    {
        Debug.Log("HandlePlayerEvent  @event.health " + @event.health);
        Debug.Log("HandlePlayerEvent  @event.mana " + @event.mana);
    }

    private void HandleTestEvent(TestEvent @event)
    {
        Debug.Log("Test event ");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EventBus<TestEvent>.Raise(new TestEvent());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            EventBus<PlayerEvent>.Raise(new PlayerEvent
            {
                health = 0,
                mana = 0

            });


        }
    }
}