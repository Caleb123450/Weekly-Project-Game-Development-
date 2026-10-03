using UnityEngine;

public class Sc_gerak1 : MonoBehaviour
{
    [SerializeField] Transform tujuan1;
    [SerializeField] Transform tujuan2;
    float kecepatan = 3f;
    Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        gerakkan5();
    }

    void gerakkan5()
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime, Space.Self);
        this.transform.Rotate(Vector3.up * 1f);
    }   
}