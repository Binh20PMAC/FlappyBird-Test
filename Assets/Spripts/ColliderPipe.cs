using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderPipe : MonoBehaviour
{

    [SerializeField]
    public static float speed = 1f;
    public static float screenWidthLeft = 0;
    public static float screenWidthRight = 0;
    private void Start()
    {
        screenWidthLeft = ((float)Screen.width / (float)Screen.height) * (-5f) - 1f;
        screenWidthRight = ((float)Screen.width / (float)Screen.height) * (5f) + 1f;
        Debug.Log(screenWidthLeft);
        Debug.Log(screenWidthRight);
    }

    private void Update()
    {
        if (screenWidthLeft > transform.position.x)
        {
            transform.position = new Vector3(screenWidthRight, Random.Range(-4, 4), 0);
        }

        transform.position += (Vector3.left * Time.deltaTime) * speed;
    }
}
