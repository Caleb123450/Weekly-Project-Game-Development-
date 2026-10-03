using UnityEngine;
using System.Collections;

public class sc_input2 : MonoBehaviour
{
    float speed = 2f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
        }
    }
}