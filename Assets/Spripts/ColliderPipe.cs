using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPipe : MonoBehaviour
{

    [SerializeField]
    public static float speed = 1f;

   

    private void Update()
    {
        if (-4 > transform.position.x)
        {
            transform.position = new Vector3 (4,Random.Range(-4,4),0);
        }

        transform.position += (Vector3.left * Time.deltaTime) * speed;
    }
}
