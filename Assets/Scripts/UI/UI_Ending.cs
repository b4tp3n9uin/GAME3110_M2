using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ending : MonoBehaviour
{
    public Text winText;
    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPlayer1Win)
            winText.text = "Player 1 Win!";
        else
            winText.text = "Player 2 Win!";
    }

    public void RetryButton()
    {
        GameManager.Instance.timeLimit = 10.0f;
        GameManager.Instance.player1Hp = 100.0f;
        GameManager.Instance.player2Hp = 100.0f;
        GameManager.Instance.IsPlayer1Turn = true;
        GameManager.Instance.IsPlayer1Win = false;
        GameManager.Instance.IsPlayer2Win = false;

        GameManager.Instance.SceneChange("Game");
    }

    public void MainButton()
    {
        GameManager.Instance.timeLimit = 10.0f;
        GameManager.Instance.player1Hp = 100.0f;
        GameManager.Instance.player2Hp = 100.0f;
        GameManager.Instance.IsPlayer1Turn = true;
        GameManager.Instance.IsPlayer1Win = false;
        GameManager.Instance.IsPlayer2Win = false;

        GameManager.Instance.SceneChange("MainMenu");
    }
}
