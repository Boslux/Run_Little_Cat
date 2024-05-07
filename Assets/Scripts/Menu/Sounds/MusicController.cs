using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource musicPlayer;
    public AudioClip[] musics;
    public Settings settings;
    public void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.loop = false;
        PlayRandomMusic();
    }
    public void Update()
    {
        Play();
    }
    void Play()
    {
        if (!musicPlayer.isPlaying)
            PlayRandomMusic();     
    }
    void PlayRandomMusic()
    {
        if (settings.soundCheck)
        {
        musicPlayer.clip = musics[Random.Range(0,musics.Length)];
        musicPlayer.Play();
        }
        else
        {
        musicPlayer.Stop();
        }

    }
}
