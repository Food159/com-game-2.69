using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject buttonSettings;

    private void Start()
    {
        SoundManager.Instance.PlayBGM();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
            buttonSettings.SetActive(!buttonSettings.activeSelf);
        }
    }
}
