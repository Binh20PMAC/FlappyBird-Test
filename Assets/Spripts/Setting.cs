using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private GameObject Volume;
    // Start is called before the first frame update
   
    public void Audio()
    {
        Volume.SetActive(true);
    }

    public void Close()
    {
        Volume.SetActive(false);
    }
}
