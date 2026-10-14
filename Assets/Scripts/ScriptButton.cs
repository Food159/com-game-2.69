using UnityEngine;
using UnityEngine.UI;

public class ScriptButton : MonoBehaviour
{
    [Header("Button Images")]
    [SerializeField] private Image bgmButtonImage;
    [SerializeField] private Image sfxButtonImage;

    [Header("Button Colors")]
    [SerializeField] private Color enabledColor = Color.white;
    [SerializeField] private Color disabledColor = Color.gray;

    private bool bgmEnabled = true;
    private bool sfxEnabled = true;

    private void Start()
    {
        UpdateButtonColors();
    }

    public void ToggleBGM()
    {
        bgmEnabled = !bgmEnabled;
        SoundManager.Instance.SetBGMEnabled(bgmEnabled);
        UpdateButtonColors();
    }

    public void ToggleSFX()
    {
        sfxEnabled = !sfxEnabled;
        SoundManager.Instance.SetVFXEnabled(sfxEnabled);
        UpdateButtonColors();
    }

    private void UpdateButtonColors()
    {
        bgmButtonImage.color = bgmEnabled ? enabledColor : disabledColor;
        sfxButtonImage.color = sfxEnabled ? enabledColor : disabledColor;
    }
}
