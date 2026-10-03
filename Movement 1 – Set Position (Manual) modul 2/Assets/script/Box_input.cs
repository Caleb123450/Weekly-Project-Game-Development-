using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_input : MonoBehaviour
{
    float speed = 3;

    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        this.transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * speed);
    }
}