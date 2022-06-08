using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public string level;
    public string gameModeSelection;

    private void Awake()
    {
        
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(level);
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GameMode()
    {
        SceneManager.LoadScene(gameModeSelection);
    }
}
