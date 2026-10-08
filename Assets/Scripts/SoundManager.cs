using UnityEngine;

public enum SfxType
{
    CoinCollect
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSound;
    [SerializeField] private AudioSource sfxSound;

    [Header("Audio Clips")]
    public AudioClip bgmClip;
    public AudioClip coinCollectSound;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
        if (bgmSound.clip != bgmClip)
        {
            bgmSound.clip = bgmClip;
            bgmSound.Play();
        }
    }

    public void PlaySfx(SfxType type)
    {
        switch (type)
        {
            case SfxType.CoinCollect:
                sfxSound.PlayOneShot(coinCollectSound);
                break;
        }
    }
}
