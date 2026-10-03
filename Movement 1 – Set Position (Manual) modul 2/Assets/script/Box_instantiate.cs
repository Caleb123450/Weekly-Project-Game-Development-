using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_instantiate : MonoBehaviour
{
    public GameObject objPrefab;

    void Update()
    {
        Instantiate(objPrefab, this.transform.position, this.transform.rotation);
    }
}