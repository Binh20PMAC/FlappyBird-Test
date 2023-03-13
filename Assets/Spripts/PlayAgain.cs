using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // Update is called once per frame
    public void Load()
    {
        SceneManager.LoadScene("SampleScene");
        AudioManager.instance.musicSource.Stop();
        
    }

    //public void LoadAgain()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //    AudioManager.instance.musicSource.Stop();

    //}
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        AudioManager.instance.musicSource.Stop();
    }
}
