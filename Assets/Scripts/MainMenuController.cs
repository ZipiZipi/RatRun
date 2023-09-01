using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
