using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public GameObject howPlayPanel;
   
    public void StartButton()
    {
        GameManager.Instance.SceneChange("Login");
    }

    public void PlayButton()
    {
        GameManager.Instance.SceneChange("Game");
    }

    public void HowPlayButton()
    {
        howPlayPanel.SetActive(true);
    }

    public void HowPlayCloseButton()
    {
        howPlayPanel.SetActive(false);
    }

    public void MainMenuButton()
    {
        GameManager.Instance.SceneChange("MainMenu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
