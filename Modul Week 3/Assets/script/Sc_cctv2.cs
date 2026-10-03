using UnityEngine;

public class Sc_cctv2 : MonoBehaviour
{
    GameObject target;

    void Start()
    {
        target = GameObject.Find("hero");
        this.transform.rotation = Quaternion.AngleAxis(45, Vector3.up);
    }

    void Update()
    {
        Vector3 jarakCctvHero = target.transform.position - this.transform.position;
        float dot = Vector3.Dot(this.transform.forward, jarakCctvHero.normalized);

        if (dot > 0f)
        {
            float angle = Mathf.Atan2(jarakCctvHero.x, jarakCctvHero.z) * Mathf.Rad2Deg;
            Quaternion rotasi = Quaternion.AngleAxis(angle, Vector3.up);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotasi, Time.deltaTime);
        }
    }
}