using UnityEngine;

public class TangentMovement : MonoBehaviour, IMoveable
{
    public float speed = 1f;
    public float amplitude = 1f;
    public float maxOffset = 1f;

    private float initialY;
    private bool MoveTrigger;

    private bool isMove = false;
    
    void Start()
    {
        MoveTrigger = false;
        initialY = transform.position.y;
        MoveManager.OnTangentMovementEvent += TangentMove;
    }

    public void Stop()
    {
        isMove = false;
    }

    public void Move()
    {
        isMove = true;
    }

    void TangentMove(bool trigger)
    {
        MoveTrigger = trigger;
    }

    void Update()
    {
        if (/*MoveTrigger*/ isMove)
        {
            float tanValue = Mathf.Tan(Time.time * speed);

            tanValue = Mathf.Clamp(tanValue, -maxOffset, maxOffset);

            float y = initialY + tanValue * amplitude;

            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }
}
