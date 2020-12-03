using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    #region Singleton
    public static AudioPlayer Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource.volume = PlayerPrefs.GetFloat(PrefsMusicVolume, 0.5f);
        }
    }
    #endregion

    [SerializeField] private AudioSource audioSource;
    private const string PrefsMusicVolume = "MusicVolume";
    public void MusicVolumeChange(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat(PrefsMusicVolume, value);
    }
    public float GetMusicVolume()
    {
        return audioSource.volume;
    }
}
