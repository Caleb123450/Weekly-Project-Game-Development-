using UnityEngine;

public class Sc_turrent : MonoBehaviour
{
    GameObject target;

    [SerializeField] GameObject peluru;
    [SerializeField] Transform titikTembak; 
    public float fireRate = 1f; 
    float fireCooldown = 0f;

    void Update()
    {
        if (target != null)
        {
            Vector3 posTarget = target.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(posTarget);

            fireCooldown -= Time.deltaTime;
            if (fireCooldown <= 0f)
            {
                Tembak();
                fireCooldown = 1f / fireRate;
            }
        }
    }

    private void Tembak()
    {
        Instantiate(peluru, titikTembak.position, titikTembak.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "musuh")
        {
            target = other.gameObject;
        }
    }
}