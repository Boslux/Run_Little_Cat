using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Settings settings;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        settings.scoreT=0;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void SoundControl()
    {
        settings.soundCheck=!settings.soundCheck;
    }
}
