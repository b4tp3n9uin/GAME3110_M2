using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // singleton design pattern
    #region singleton
    private static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    #endregion
    
    // time limitation 
    public float timeLimit = 10.0f;
    // HP
    public float player1Hp = 100.0f;
    // HP2
    public float player2Hp = 100.0f;

    public int playerNum;

    public bool IsPlayer1Turn = true;
    public bool IsPlayer1Win = false;
    public bool IsPlayer2Win = false;

    // scene changer
    public void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
