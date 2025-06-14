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

    public static event Action<Vector3, AudioType> OnRunSoundEvent;
    public static event Action<Vector3, AudioType> OnJumpSoundEvent;

    public PlayerData playerData;
    public Animator anim;
    public MainUI mainUI;

    public int MaxPower = 100;
    public float originalMoveSpeed = 5.0f;
    public float originalJumpForce = 5.0f;

    public Vector3 originalPosition;
    public Quaternion originalRotation;

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
        playerData.OnGameOverEvent += GameOver;
        playerData.OnPlayerDeadEvent += PlayerDead;
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

    public void PlayerDead()
    {
        OriginalTransform();
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
            anim.SetBool("Run", true);
            transform.position += Vector3.left * playerData.MoveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 270, 0);
            OnRunSoundEvent?.Invoke(transform.position, AudioType.Run);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
            anim.SetBool("Run", false);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Run", true);
            transform.position += Vector3.right * playerData.MoveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 90, 0);
            OnRunSoundEvent?.Invoke(transform.position, AudioType.Run);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
            anim.SetBool("Run", false);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("Run", true);
            transform.position += Vector3.forward * playerData.MoveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            OnRunSoundEvent?.Invoke(transform.position, AudioType.Run);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
            anim.SetBool("Run", false);

        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Run", true);
            transform.position -= Vector3.forward * playerData.MoveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            OnRunSoundEvent?.Invoke(transform.position, AudioType.Run);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
            anim.SetBool("Run", false);

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            rb.AddForce(Vector3.up * playerData.JumpForce, ForceMode.Impulse);
            OnJumpSoundEvent?.Invoke(transform.position, AudioType.Run);
            isGrounded = false;
        }
    }
}