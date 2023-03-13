using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Birds : NormalBird
{
    private void Update()
    {
        base.BirdJump(gameObject);
        base.Fire();

        if (PlayerPrefs.GetInt("selectedOptions") == 1)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                Time.timeScale = 0;
            }
        }
        if (PlayerPrefs.GetInt("selectedOptions") == 2)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Time.timeScale = 0;
            }
        }
    }
}
