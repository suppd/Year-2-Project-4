using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour //, ISelectHandler
{
    public string level;
    public GameObject ButtonGameObject;

    public void OnSelect()
    {
     //   if (eventData.selectedObject == ButtonGameObject)
        {
            Debug.Log(this.ButtonGameObject.name + " was selected");
        }
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
}
