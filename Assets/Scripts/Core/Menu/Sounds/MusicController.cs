using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource _musicPlayer;
    public AudioClip[] musics;
    public Settings settings;

    void Start()
    {
        _musicPlayer = GetComponent<AudioSource>();
        _musicPlayer.loop = false;

        if (settings.soundCheck)
        {
            PlayRandomMusic();
        }
        else
        {
            _musicPlayer.Stop();
        }
    }

    void Update()
    {
        if (!_musicPlayer.isPlaying && settings.soundCheck)
        {
            PlayRandomMusic();
        }
    }

    private void PlayRandomMusic()
    {
        _musicPlayer.clip = musics[Random.Range(0, musics.Length)]; //rastgele müzik seç
        _musicPlayer.Play(); //müziği başlat
    }
}
