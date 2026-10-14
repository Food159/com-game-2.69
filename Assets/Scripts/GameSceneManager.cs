using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMainMenuScene()
    {
        SoundManager.Instance.StopBGM();
        LoadGameScene("MainMenu");
    }

    public void LoadGameScene()
    {
        LoadGameScene("MainGame");
    }

    public void RestartScene()
    {
        LoadGameScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
