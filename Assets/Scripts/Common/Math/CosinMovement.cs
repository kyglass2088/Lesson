using UnityEditor.Toolbars;
using UnityEngine;

public class CosinMovement : MonoBehaviour, IMoveable
{
    public float speed = 1f;
    public float amplitude = 1f;
    private float initialX;
    private bool MoveTrigger;

    private bool isMove = false;

    public void Start()
    {
        MoveTrigger = false;
        initialX = transform.position.x;
        MoveManager.OnCosineMovementEvent += CosineMove;
    }

    public void Stop()
    {
        isMove = false;
    }

    public void Move()
    {
        isMove = true;
    }
    void CosineMove(bool trigger)
    {
        MoveTrigger = trigger;
    }

    void Update()
    {
        if (/*MoveTrigger*/ isMove)
        {
            float x = initialX + Mathf.Cos(Time.time * speed) * amplitude;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
    }
}
