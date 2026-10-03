using UnityEngine;

public class MoveLeftRight : MonoBehaviour
{
    public float speed = 2f;
    private bool movingRight = true;
    public float leftLimit = -5f;
    public float rightLimit = 5f;

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= rightLimit) movingRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x <= leftLimit) movingRight = true;
        }
    }
}