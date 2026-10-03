using UnityEngine;

public class Sc_camera : MonoBehaviour
{
    GameObject hero;

    void Start()
    {
        hero = GameObject.Find("hero");
    }

    void Update()
    {
        float speed = 0f;
        if (Input.GetKey(KeyCode.LeftShift)) speed = 50;
        if (Input.GetKey(KeyCode.RightShift)) speed = -50;

        this.transform.LookAt(hero.transform);
        this.transform.RotateAround(hero.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}