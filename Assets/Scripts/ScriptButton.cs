using UnityEngine;

public class ScriptButton : MonoBehaviour
{
    private bool bgmEnabled = true;
    private bool sfxEnabled = true;

    public void ToggleBGM()
    {
        bgmEnabled = !bgmEnabled;
        SoundManager.Instance.SetBGMEnabled(bgmEnabled);
    }

    public void ToggleSFX()
    {
        sfxEnabled = !sfxEnabled;
        SoundManager.Instance.SetVFXEnabled(sfxEnabled);
    }
}
