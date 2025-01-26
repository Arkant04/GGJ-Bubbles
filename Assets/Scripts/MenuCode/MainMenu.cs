using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadMap(string mapName)
    {
        SceneManager.LoadScene(mapName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
