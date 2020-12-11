using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Login : MonoBehaviour
{
    public GameObject createPanel;

    public void CreatePanelOn()
    {
        createPanel.SetActive(true);
    }
    public void CreatePanelOff()
    {
        createPanel.SetActive(false);
    }
}
