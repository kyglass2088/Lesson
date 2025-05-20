using NUnit.Framework.Internal;
using System;
using System.Diagnostics.Tracing;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Player.OnPlayerHitSomethingEvent += Player_OnPlayerHitSomethingEvent;
    }

    private void Player_OnPlayerHitSomethingEvent()
    {

    }
}

public class Player : MonoBehaviour
{
    public Animator anim;

    public int Power = 100;
    public float Damage;

    public float moveSpeed = 5f;
    private float horizontalInput;

    // 이벤트 퍼블리셔
    public static event Action OnPlayerHitSomethingEvent;
    public static event Action<GameObject> OnPlayerHitSomethingEventWithObj;

    private void OnCollisionEnter(Collision collision)
    {
        OnPlayerHitSomethingEvent?.Invoke();

        OnPlayerHitSomethingEventWithObj?.Invoke(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnPlayerHitSomethingEventWithObj?.Invoke(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.W))
            transform.position.x += Vector3.forward * moveSpeed;

        if (Input.GetKeyDown(KeyCode.A))
            transform.right += Vector3.forward * moveSpeed;

        if (Input.GetKeyDown(KeyCode.S))
            transform.forward += -Vector3.forward * moveSpeed;

        if (Input.GetKeyDown(KeyCode.D))
            transform.right += Vector3.forward * moveSpeed;

        //transform.Translate(Vector3.forward * moveSpeed * horizontalInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("Attack01");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetTrigger("Attack04");
        }
    }
}