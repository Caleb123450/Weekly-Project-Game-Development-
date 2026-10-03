using UnityEngine;

public class Sc_peluru : MonoBehaviour
{
    public float speed = 15f;
    public float umurPeluru = 3f;

    void Start()
    {
        Destroy(this.gameObject, umurPeluru);
    }

    void Update()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "musuh")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}