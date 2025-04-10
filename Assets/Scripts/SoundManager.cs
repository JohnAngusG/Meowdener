using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;


    
    static public SoundManager Instance { get; private set; } = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else { 
            Destroy(gameObject);
        }
    }


    private void Init()
    {
        
    }


    public void PlaySfx(AudioClip clip, float volume = 1.0f) {
        sfxSource.PlayOneShot(clip, volume);
    
    }

    public void PlayMusic() {
        musicSource.Play();
    }

    public void StopMusic() {
        musicSource.Stop();
    }

}
