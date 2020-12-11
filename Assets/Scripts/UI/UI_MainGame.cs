using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainGame : MonoBehaviour
{
    public Text time;
    public Text WinMessage;
    public Image player1HP;
    public Image player2HP;
    public float player1Amount;
    public float player2Amount;
    public Player player;

    private float count;

    void Update()
    {
        player1Amount = GameManager.Instance.player1Hp / 100.0f;
        player2Amount = GameManager.Instance.player2Hp / 100.0f;

        player1HP.fillAmount = player1Amount;
        player2HP.fillAmount = player2Amount;

        GameManager.Instance.timeLimit -= Time.deltaTime;

        time.text = "Time limit : " + GameManager.Instance.timeLimit.ToString("N2");

        if(GameManager.Instance.timeLimit <= 0.0f)
        {
            player.ChangeTurn();
            GameManager.Instance.timeLimit = 10.0f;
        }

        if(GameManager.Instance.IsPlayer1Win)
        {
            WinMessage.enabled = true;
            WinMessage.text = "Player 1 Win";
            Invoke("GoToEnding", 2.0f);
        }
        else if (GameManager.Instance.IsPlayer2Win)
        {
            WinMessage.enabled = true;
            WinMessage.text = "Player 2 Win";
            Invoke("GoToEnding", 2.0f);
        }
    }

    public void GoToEnding()
    {
        GameManager.Instance.SceneChange("Ending");
    }
}
