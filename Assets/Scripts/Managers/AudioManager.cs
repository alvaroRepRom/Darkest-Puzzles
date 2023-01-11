using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioClip mainMusic;
    [SerializeField] private AudioClip alertMusic;
    [SerializeField] private OnAlertSO onAlertSO;

    private AudioSource audioSource;

    private void OnEnable() => onAlertSO.onAlert += ChangeMusic;
    private void OnDisable() => onAlertSO.onAlert -= ChangeMusic;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource.Play();
    }

    private void ChangeMusic(bool change)
    {
        if (change && audioSource.clip == mainMusic)
        {
            audioSource.clip = alertMusic;
            audioSource.Play();
        }
        else 
        if(!change && audioSource.clip == alertMusic)
        {
            audioSource.clip = mainMusic;
            audioSource.Play();
        }
    }
}
