using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        SceneManager.LoadScene(0);
    }
    public void SoundControl()
    {
        settings.soundCheck=!settings.soundCheck;
    }
}
