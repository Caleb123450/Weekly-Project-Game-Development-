using UnityEngine;

public class MoveAndCollide : MonoBehaviour
{
    void Update()
    {
        this.transform.Translate(Vector3.left * 10f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("Box collide dengan " + col.gameObject.name);
    }
}   