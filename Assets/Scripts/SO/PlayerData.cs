using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public event Action OnGameOverEvent;
    public event Action OnPlayerDeadEvent;

    EventBinding<PlayerEvent> playerEventBinding;
    private int hp;
    public int MaxHp = 100;

    //private void OnEnable()
    //{
    //    playerEventBinding = new EventBinding<PlayerEvent>(PlayerEventHandler);
    //    EventBus<PlayerEvent>.Register(playerEventBinding);
    //}

    //private void PlayerEventHandler(Player @event)
    //{
    //    Debug.Log("@event");
    //    Debug.Log(@event);
    //}

    public int HP
    {
        get { return hp; }
        set { hp = value;

            if (hp <= 0)
            {
                Life--;
                hp = MaxHp;
                OnPlayerDeadEvent?.Invoke();
            }
        }
    }
    [field:SerializeField]
    private int life = 5;
    public int Life
    {
        get 
        {
            Debug.Log("Life get");
            return life;
        }
        set
        {
            life = value;
            Debug.Log("Life set");
            OnGameOverEvent?.Invoke();

            if (life == 0)
            {
                OnGameOverEvent?.Invoke();
                EventBus<PlayerEvent>.Raise(new PlayerEvent
                {
                    health = 100,
                    mana = 100
                });

                EventBus<TestEvent>.Raise(new TestEvent { });

                OnGameOverEvent?.Invoke();
            }
        }
    }


    public float OriginalMoveSpeed = 5f;
    public float OriginalJumpSpeed = 5f; 

    public float JumpForce = 5f;
    public float MoveSpeed = 5;
    public float bounceForce = 10f;
}
