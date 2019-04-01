using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource battleMusicSource;
    public AudioSource overworldMusicSource;
    public AudioSource sfxSource;
    public float lowPitch = 0.95f;
    public float highPitch = 1.05f;

    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    
    public void PlayOverworldMusic ()
    {
        overworldMusicSource.volume = 0;
        overworldMusicSource.Play();
    }
    public void PlayBattleMusic()
    {
        battleMusicSource.volume = 0;
        battleMusicSource.Play();
    }

    public void RandomizePitchAndPlay (AudioClip Clip)
    {
        float randomPitch = Random.Range(lowPitch, highPitch);
        sfxSource.clip = Clip;
        sfxSource.pitch = randomPitch;
        sfxSource.Play();
    }

    public IEnumerator CrossFadeToBattle ()
    {
        if (!battleMusicSource.isPlaying)
        {
            PlayBattleMusic();
        }
        while (overworldMusicSource.volume > 0.01f)
        {
            overworldMusicSource.volume -= 0.01f;
            battleMusicSource.volume += 0.005f;
            yield return null;
        }
    }

    public IEnumerator CrossFadeToOverworld()
    {
        if (!overworldMusicSource.isPlaying)
        {
            PlayOverworldMusic();
        }
        while (battleMusicSource.volume > 0.01f)
        {
            overworldMusicSource.volume += 0.01f;
            battleMusicSource.volume -= 0.005f;
            yield return null;
        }
    }

}
