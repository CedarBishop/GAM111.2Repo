using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource musicSource;
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
    
    public void PlayMusic (AudioClip Clip)
    {
        musicSource.clip = Clip;
        musicSource.Play();
    }

    public void RandomizePitchAndPlay (AudioClip Clip)
    {
        float randomPitch = Random.Range(lowPitch, highPitch);
        sfxSource.clip = Clip;
        sfxSource.pitch = randomPitch;
        sfxSource.Play();
    }
}
