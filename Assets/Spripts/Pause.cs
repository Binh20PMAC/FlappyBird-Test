using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause instance;
    [SerializeField]
    private GameObject Setting;

    private bool pause = true;
    private void Awake()
    {
        instance = this;
        //DontDestroyOnLoad(CanvasVolume);
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(CanvasVolume);
        //}
        //else
        //{
        //    Destroy(CanvasVolume);
        //}
    }

  
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            if(!pause)
            {
                Setting.gameObject.SetActive(true);
            }
            else
            {
                Setting.gameObject.SetActive(false);
            }
        }
        Time.timeScale = (pause) ? 1.0f : 0.0f;
    }

    public void Continute()
    {
        AudioManager.instance.PlaySFX("Play");
        pause = !pause;
        if (!pause)
        {
            Setting.gameObject.SetActive(true);
        }
        else
        {
            Setting.gameObject.SetActive(false);
        }
    
    Time.timeScale = (pause)? 1.0f : 0.0f;
    }

    public void Pauses()
    {
        pause = !pause;
        if (!pause)
        {
            Setting.gameObject.SetActive(true);
        }
        else
        {
            Setting.gameObject.SetActive(false);
        }

        Time.timeScale = (pause) ? 1.0f : 0.0f;
    }
}
