using UnityEngine;

public class SineVerticalMovement : MonoBehaviour, IMoveable
{
    public float speed = 1f;
    public float amplitude = 1f;
    private float startY;
    private bool MoveTrigger;

    private bool isMove = false;

    void Start()
    {
        MoveTrigger = false;
        startY = transform.position.y;
        MoveManager.OnSineMovementEvent += SineMove;
    }

    public void Stop()
    {
        isMove = false;
    }

    public void Move()
    {
        isMove = true;
    }

    void SineMove(bool trigger)
    {
        MoveTrigger = trigger;
    }

    void Update()
    {
        if (/*MoveTrigger*/ isMove)
        {
            float y = startY + Mathf.Sin(Time.time * speed) * amplitude;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }
}
