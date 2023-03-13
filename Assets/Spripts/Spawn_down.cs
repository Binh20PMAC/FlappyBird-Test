using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawn_down : MonoBehaviour
{

    [SerializeField]
    private GameObject Pipe;
    [SerializeField]
    private float spawnrate = 2.8f;
    [SerializeField]
    private float minheight = -2f;
    [SerializeField]
    private float maxheight = 2f;
    [SerializeField]
   


    private void Start()
    {
        InvokeRepeating(nameof(Spawner), spawnrate, spawnrate);
    }

    //private void OnDisable()
    //{
    //    CancelInvoke(nameof(Spawner));
    //}
    private void Spawner()
    {
        GameObject pipes = SimplePool.Spawn(Pipe, transform.position, Quaternion.identity);//Instantiate(Pipe, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minheight, maxheight);
    }
  
}

