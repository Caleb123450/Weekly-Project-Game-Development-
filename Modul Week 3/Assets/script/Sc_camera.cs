using UnityEngine;

public class Sc_camera : MonoBehaviour
{
    GameObject hero;
    public float zoomSpeed = 10f;
    public float minDistance = 2f;
    public float maxDistance = 15f;

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

        float currentDistance = Vector3.Distance(this.transform.position, hero.transform.position);

        if (Input.GetKey(KeyCode.Alpha1) && currentDistance > minDistance)
        {
            this.transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.Alpha2) && currentDistance < maxDistance)
        {
            this.transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime, Space.Self);
        }
    }
}