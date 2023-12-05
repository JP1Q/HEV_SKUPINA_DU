using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] musicClips;
    private AudioSource audioSource;

    // Chcem aby jenom jeden audioman. existoval <333
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject audioManagerObject = new GameObject("AudioManager");
                instance = audioManagerObject.AddComponent<AudioManager>();
                DontDestroyOnLoad(audioManagerObject);
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false; // Uz chci spat >:) 
        PlayRandomMusic();
    }

    void PlayRandomMusic()
    {
        if (musicClips.Length > 0)
        {
            int randomIndex = Random.Range(0, musicClips.Length);
            audioSource.clip = musicClips[randomIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No music clips assigned to AudioManager.");
        }
    }

    // Chcem random audioasdhfjkahsdgkljhsdahjfgsdfglkjhjk
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayRandomMusic();
        }
    }
}
