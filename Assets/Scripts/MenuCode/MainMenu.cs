using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("PuntosP1", 0);
        PlayerPrefs.SetInt("PuntosP2", 0);
    }

    public void LoadMap(string mapName)
    {
        SceneManager.LoadScene(mapName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
