using System;
using UnityEngine;
using UnityEngine.UIElements;

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
    private Rigidbody rb;

    public int Power = 100;
    public float Damage;

    public float moveSpeed = 5f;
    private float jumpForce = 5.0f;
    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // 이벤트 퍼블리셔
    public static event Action OnPlayerHitSomethingEvent;
    public static event Action<GameObject> OnPlayerHitSomethingEventWithObj;

    private void OnTriggerEnter(Collider other)
    {
        OnPlayerHitSomethingEvent?.Invoke();
        OnPlayerHitSomethingEventWithObj?.Invoke(other.gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        OnPlayerHitSomethingEvent?.Invoke();
        OnPlayerHitSomethingEventWithObj?.Invoke(collision.gameObject);

        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground");
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("Item");
        }
        else if (collision.gameObject.CompareTag("Trap"))
        {
            Power -= 20;
            Debug.Log("Trap");
        }
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= Vector3.forward * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

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