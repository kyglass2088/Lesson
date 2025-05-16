using NUnit.Framework.Internal;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Power = 100;
    public float Damage;
    public MainUI mainUI;

    EventBinding<TestEvent> testEventBinding;
    EventBinding<PlayerEvent> playerEventBinding;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Item Collision");
        Power += 50;
        if (collision.gameObject.name == "item")
        {
            Debug.Log("Item Collision");
        }
        if (collision.gameObject.name != "item")
        {
            //Power -= 50;
            Debug.Log("Not Item Collision");
        }

        mainUI.UpdatePowerSlider(Power);
    }

    private void OnEnable()
    {
        testEventBinding = new EventBinding<TestEvent>(HandleTestEvent);
        EventBus<TestEvent>.Register(testEventBinding);

        playerEventBinding = new EventBinding<PlayerEvent>(HandlePlayerEvent);
        EventBus<PlayerEvent>.Register(playerEventBinding);
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

    int MyMethodWithParam(int number)
    {
        Debug.Log("MyMethodWithParam! " + number);

        return number * number;
    }

    void MyMethod()
    {
        Debug.Log("myAction!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            EventBus<TestEvent>.Raise(new TestEvent());
        }
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    EventBus<PlayerEvent>.Raise(new PlayerEvent
        //    {
        //        health = 0,
        //        mana = 0,
        //        myAction = MyMethod,
        //        myFunc = MyMethodWithParam
        //    });


        //}
    }
}