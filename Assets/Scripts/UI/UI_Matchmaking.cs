using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Matchmaking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadGame");
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Game");
    }
}
