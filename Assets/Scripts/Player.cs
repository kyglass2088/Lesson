using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 이벤트 퍼블리셔
    public static event Action OnPlayerHitSomethingEvent;
    public static event Action OnGameOverEvent;
    public static event Action<GameObject> OnPlayerHitSomethingEventWithObj;

    public PlayerData playerData;
    public Animator anim;

    private Rigidbody rb;
    public MainUI mainUI;
    Quaternion originalRotation;
    Vector3 originnalPosition;

    private float originalMoveSpeed = 5.0f;
    private float originalJumpForce = 5.0f;

    public float MaxPower = 100;

    public float Power;
    public float Damage;

    public float moveSpeed = 5f;
    private float jumpForce = 5.0f;
    private bool isGrounded = true;
    private const int minHp = 0;

    void StandUp()
    {
        transform.rotation = originalRotation;
    }

    private void Start()
    {
        Power = MaxPower;
        originalRotation = transform.rotation;
        originnalPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        Goal.OnGameClearEvent += GameClear;
        playerData.HP = Power;
    }

    public void InstanceKill()
    {
        playerData.Life--;
        transform.position = originnalPosition;
        playerData.HP = MaxPower;
        if (playerData.Life <= 0)
            OnGameOverEvent?.Invoke();
    }

    public void GameClear()
    {
        moveSpeed = 0f;
        jumpForce = 0f;
    }

    public void MoveDisturbance(float speed, float jumpforce)
    {
        moveSpeed -= speed;
        jumpForce -= jumpforce;
        playerData.MoveSpeed = moveSpeed;
        playerData.JumpForce = jumpForce;
    }

    public void InitializeMovement()
    {
        moveSpeed = originalMoveSpeed;
        jumpForce = originalJumpForce;
        playerData.MoveSpeed = moveSpeed;
        playerData.JumpForce = jumpForce;
    }

    public void CommonTrap(float Damage)
    {
        //rb.AddForce(new Vector3(3, 0, 30), ForceMode.Impulse);
        Power -= Damage;
        mainUI.UpdateDecreaseHpBar(Damage);
        playerData.HP = Power;

        if (Power <= minHp)
        {
            Power = MaxPower;
            transform.position = originnalPosition;
            playerData.Life--;
            if (playerData.Life <= 0)
                OnGameOverEvent?.Invoke();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //OnPlayerHitSomethingEvent?.Invoke();
        //OnPlayerHitSomethingEventWithObj?.Invoke(other.gameObject);
    }
    void OnCollisionEnter(Collision collision)
    {
        //OnPlayerHitSomethingEvent?.Invoke();
        //OnPlayerHitSomethingEventWithObj?.Invoke(collision.gameObject);
        StandUp();
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground");
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Item"))
        {
            Debug.Log("Item");
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
    }
}