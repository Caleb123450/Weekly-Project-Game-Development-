using UnityEngine;

public class Sc_Lab5_CameraController : MonoBehaviour
{
    private GameObject hero;
    public float panjangRay = 300f;
    public float kecepatanSmooth = 10f; // Kecepatan transisi kamera agar pergerakan halus
    float sudutY;
    float jarakDefault = 2.5f;

    void Start()
    {
        hero = GameObject.Find("hero");

        // hitung sudut vertikal awal dari posisi kamera saat ini terhadap hero
        Vector3 arah = this.transform.position - hero.transform.position;
        Vector3 arahDatar = new Vector3(arah.x, 0, arah.z);
        sudutY = Vector3.Angle(arahDatar, arah);
    }

    void LateUpdate()
    {
        if (hero == null) return;

        // 1. Orbit kamera mengikuti mouse (horizontal bebas, vertikal dibatasi 0-70 derajat)
        this.transform.RotateAround(hero.transform.position, Vector3.up, Input.GetAxis("Mouse X") * 4f);

        float inputY = Input.GetAxis("Mouse Y") * 4f;
        float sudutBaru = Mathf.Clamp(sudutY + inputY, 0f, 70f);
        float delta = sudutBaru - sudutY;
        sudutY = sudutBaru;
        this.transform.RotateAround(hero.transform.position, Vector3.left, delta);

        // Posisi ideal kamera sekarang hasil orbit mouse (bukan offset statis)
        Vector3 targetCameraPos = this.transform.position;

        Vector3 rayDirection = hero.transform.position - targetCameraPos;
        float distanceToHero = rayDirection.magnitude;

        // 2. Cek Raycast dari Kamera ke Hero (Hanya saat tembok menghalangi)
        RaycastHit hit;
        Debug.DrawRay(targetCameraPos, rayDirection, Color.red);

        if (Physics.Raycast(targetCameraPos, rayDirection.normalized, out hit, distanceToHero))
        {
            // Jika garis terhalang oleh objek bernama "tembok"
            if (hit.transform.name == "tembok")
            {
                // Pindahkan target kamera persis di depan titik benturan tembok
                targetCameraPos = hit.point + (rayDirection.normalized * -0.2f);
            }
        }

        // 3. Pergerakan Smooth menggunakan Vector3.Lerp
        this.transform.position = Vector3.Lerp(this.transform.position, targetCameraPos, Time.deltaTime * kecepatanSmooth);

        // 4. Arahkan Kamera ke Hero
        this.transform.LookAt(hero.transform);
    }
}