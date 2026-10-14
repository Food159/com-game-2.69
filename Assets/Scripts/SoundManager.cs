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

    private bool isGameBGMRequested;
    private bool isBGMEnabled = true;
    private bool isSFXEnabled = true;

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

    public void SetBGMEnabled(bool enabled)
    {
        isBGMEnabled = enabled;

        if (!isBGMEnabled)
        {
            bgmSound.Stop();
        }
        else if (isGameBGMRequested)
        {
            PlayBGM();
        }
    }

    public void SetVFXEnabled(bool enabled)
    {
        isSFXEnabled = enabled;
    }

    public void PlayBGM()
    {
        isGameBGMRequested = true;

        if (!isBGMEnabled) return;

        if (bgmSound.clip != bgmClip)
        {
            bgmSound.clip = bgmClip;
        }

        if (!bgmSound.isPlaying)
        {
            bgmSound.Play();
        }
    }

    public void StopBGM()
    {
        isGameBGMRequested = false;
        bgmSound.Stop();
    }

    public void PlaySfx(SfxType type)
    {
        if (!isSFXEnabled) return;

        switch (type)
        {
            case SfxType.CoinCollect:
                sfxSound.PlayOneShot(coinCollectSound);
                break;
        }
    }
}
