using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sound : MonoBehaviour
{
    [SerializeField]
    private AudioClip Jump;

    [SerializeField]
    private AudioClip Die;

    [SerializeField]
    private AudioClip Point;

    [SerializeField]
    private AudioClip Play;

    [SerializeField]
    private AudioClip Hit;

    [SerializeField]
    private AudioClip Tab;

    [SerializeField]
    private AudioSource saw;

    [SerializeField]
    private float MusicVolume = 1f;

    //[SerializeField]
    //private Slider volumeSlider;

    public static Sound instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        saw = GetComponent<AudioSource>();
    }
    //private void Update()
    //{
    //    saw.volume = MusicVolume;
    //}

    public void jump()
    {
        saw.PlayOneShot(Jump);
    }
    public void point()
    {
        saw.PlayOneShot(Point);
    }
    public void die()
    {
        saw.PlayOneShot(Die);
    }
    public void hit()
    {
        saw.PlayOneShot(Hit);
    }

    public void play()
    {
        saw.PlayOneShot(Play);
    }

    public void tap()
    {
        saw.PlayOneShot(Tab);
    }
        
}
