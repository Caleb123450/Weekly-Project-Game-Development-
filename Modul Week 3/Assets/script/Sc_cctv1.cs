using UnityEngine;

public class Sc_cctv1 : MonoBehaviour
{
    GameObject target;
    public float viewAngleThreshold = 0f; 

    void Start()
    {
        target = GameObject.Find("hero");
    }

    void Update()
    {
        Vector3 jarakCctvHero = target.transform.position - this.transform.position;
        float dot = Vector3.Dot(this.transform.forward, jarakCctvHero.normalized);

        if (dot > viewAngleThreshold)
        {
            Quaternion rot = Quaternion.LookRotation(jarakCctvHero);
            this.transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.Euler(0, rot.eulerAngles.y, 0),
                10f * Time.deltaTime
            );
        }

        Debug.DrawRay(target.transform.position, jarakCctvHero, dot > viewAngleThreshold ? Color.red : Color.gray);
    }
}