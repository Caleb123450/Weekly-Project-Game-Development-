using UnityEngine;

public class Sc_cctv3 : MonoBehaviour
{
    void Update()
    {
        Quaternion target = Quaternion.Euler(0, 180, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, 10f * Time.deltaTime);
    }
}