using UnityEngine;

public class RectangleMove : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 topRight;
    private Vector3 topLeft;
    private Vector3 bottomLeft;
    private Vector3 bottomRight;

    private enum State { MoveRight, MoveUp, MoveLeft, MoveDown }
    private State currentState;

    void Start()
    {
        bottomRight = bottomLeft + new Vector3(10f, 0, 0);
        topRight = bottomRight + new Vector3(0, 6f, 0);
        topLeft = bottomLeft + new Vector3(0, 6f, 0);

        currentState = State.MoveRight;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.MoveRight:
                MoveTo(bottomRight, State.MoveUp);
                break;
            case State.MoveUp:
                MoveTo(topRight, State.MoveLeft);
                break;
            case State.MoveLeft:
                MoveTo(topLeft, State.MoveDown);
                break;
            case State.MoveDown:
                MoveTo(bottomLeft, State.MoveRight);
                break;
        }
    }

    void MoveTo(Vector3 target, State nextState)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            currentState = nextState;
        }
    }
}