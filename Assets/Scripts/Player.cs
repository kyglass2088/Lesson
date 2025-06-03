using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform m_PlayerContainer;
    [SerializeField] Transform m_Player;

    // 이벤트 퍼블리셔
    public static event Action OnPlayerHitSomethingEvent;
    public static event Action OnGameOverEvent;
    public static event Action<GameObject> OnPlayerHitSomethingEventWithObj;

    public PlayerData playerData;
    public Animator anim;
    public MainUI mainUI;

    public float MaxPower = 100;
    public float originalMoveSpeed = 5.0f;
    public float originalJumpForce = 5.0f;

    public Vector3 originalPosition = Vector3.zero;
    public Quaternion originalRotation = Quaternion.identity;

    private Rigidbody rb;

    private bool isGrounded = true;

    void StandUp()
    {
        transform.rotation = originalRotation;
    }

    private void Start()
    {
        playerData.HP = MaxPower;
        playerData.MoveSpeed = originalMoveSpeed;
        playerData.JumpForce = originalJumpForce;

        originalRotation = transform.rotation;
        originalPosition = transform.position;

        rb = GetComponent<Rigidbody>();
        Goal.OnGameClearEvent += GameClear;
    }

    public void OriginalTransform()
    {
        transform.rotation = originalRotation;
        transform.position = originalPosition;
    }

    public void GameClear()
    {
        playerData.MoveSpeed = 0f;
        playerData.JumpForce = 0f;
    }

    public void GameOver()
    {
        playerData.MoveSpeed = 0f;
        playerData.JumpForce = 0f;
        OnGameOverEvent?.Invoke();
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
            transform.position += Vector3.left * playerData.MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * playerData.MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * playerData.MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= Vector3.forward * playerData.MoveSpeed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            rb.AddForce(Vector3.up * playerData.JumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}