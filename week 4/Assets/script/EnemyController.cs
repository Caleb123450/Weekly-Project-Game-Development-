using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform[] point;

    int idxPoint = 0;
    float kec = 3f;
    [SerializeField] float kecMengejar = 5f;
    [SerializeField] float waktuTunggu = 3f;

    float timerTunggu = 0f;
    bool sedangMenunggu = false;
    Transform hero;
    bool sedangMengejar = false;

    void Update()
    {
        // MODE MENGEJAR HERO
        if (sedangMengejar && hero != null)
        {
            Vector3 targetHero = new Vector3(
                hero.position.x,
                transform.position.y,
                hero.position.z
            );

            transform.position = Vector3.MoveTowards(
                transform.position,
                targetHero,
                kecMengejar * Time.deltaTime
            );

            Vector3 arahHero =
                targetHero - transform.position;

            if (arahHero != Vector3.zero)
            {
                transform.rotation =
                    Quaternion.LookRotation(
                        arahHero,
                        Vector3.up
                    );
            }

            return;
        }
        // MODE MENUNGGU
        if (sedangMenunggu)
        {
            timerTunggu -= Time.deltaTime;

            if (timerTunggu <= 0)
            {
                sedangMenunggu = false;
            }

            return;
        }
        // MODE PATROL
        Vector3 posTarget = new Vector3(
            point[idxPoint].position.x,
            transform.position.y,
            point[idxPoint].position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            posTarget,
            kec * Time.deltaTime
        );

        Vector3 posPutaranTarget =
            posTarget - transform.position;

        if (posPutaranTarget != Vector3.zero)
        {
            transform.rotation =
                Quaternion.LookRotation(
                    posPutaranTarget,
                    Vector3.up
                );
        }

        Vector3 posMusuh = new Vector3(
            transform.position.x,
            point[idxPoint].position.y,
            transform.position.z
        );

        if (Vector3.Distance(
            posMusuh,
            point[idxPoint].position
        ) < 0.1f)
        {
            if (idxPoint == point.Length - 1)
            {
                sedangMenunggu = true;
                timerTunggu = waktuTunggu;
            }
            else
            {
                idxPoint++;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hero = other.transform;
            sedangMengejar = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hero = null;
            sedangMengejar = false;
        }
    }
}