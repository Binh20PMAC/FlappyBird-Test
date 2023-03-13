using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontMove : MonoBehaviour
{
    [SerializeField] private GameObject Pipe;
        private void Update()
        {
            Pipe.transform.position = new Vector3(10,0,0);
        }
}
