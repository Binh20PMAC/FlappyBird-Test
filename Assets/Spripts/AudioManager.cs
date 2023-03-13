using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sounds[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        instance = this;
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void Start()
    {
        PlayMusic("Theme");
        musicSource.volume = PlayerPrefs.GetFloat("MusicSlider", 0);
        sfxSource.volume = PlayerPrefs.GetFloat("SFXSlider", 0);

       if(PlayerPrefs.GetInt("MusicMute") == 1)
        {
            musicSource.mute = true;
        }
       else
        {
            musicSource.mute = false;
        }

        if (PlayerPrefs.GetInt("SFXMute") == 1)
        {
            sfxSource.mute = true;
        }
        else
        {
            sfxSource.mute = false;
        }

    }
    public void PlayMusic(string name)
    {
        Sounds s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sounds s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound SFX not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        if (musicSource.mute)
        {
            PlayerPrefs.SetInt("MusicMute", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MusicMute", 0);
        }
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        if (sfxSource.mute)
        {
            PlayerPrefs.SetInt("SFXMute", 1);
        }
        else
        {
            PlayerPrefs.SetInt("SFXMute", 0);
        }
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicSlider", musicSource.volume);
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXSlider", sfxSource.volume);
    }
}
