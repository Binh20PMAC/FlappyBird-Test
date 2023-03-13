using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;

    [SerializeField]
    private List<GameObject> poolObject = new List<GameObject>();
    //private int amountToPool = 15;

    [SerializeField]
    private GameObject bulletPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //for(int i = 0; i < amountToPool; i++) 
        //{
        //    GameObject obj =  Instantiate(bulletPrefab);
        //    obj.SetActive(false);
        //    poolObject.Add(obj);
        //}
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolObject.Count; i++)
        {
            if (!poolObject[i].activeInHierarchy)
            {
                return poolObject[i];
            }
        }
        return null;
    }
}
