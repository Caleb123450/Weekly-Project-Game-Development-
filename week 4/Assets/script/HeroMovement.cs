using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(
            horizontal,
            0,
            vertical
        );

        if (movement.magnitude > 0.1f)
        {
            transform.Translate(
                movement * speed * Time.deltaTime,
                Space.World
            );

            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}