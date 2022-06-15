using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public string level;

    public void OnSelect(BaseEventData eventData)
    {
        FindObjectOfType<AudioManager>().Play("MenuHover");

        //Debug.Log(this.ButtonGameObject.name + " was selected");
    }

    public void OnDeselect(BaseEventData eventData)
    {
        //Debug.Log(this.ButtonGameObject.name + " was deselected");
    }

    public void Ready()
    {
        FindObjectOfType<AudioManager>().Play("ReadyClick");
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(level);
        FindObjectOfType<AudioManager>().Play("MenuClick");
    }

    public void Options()
    {
        Debug.Log("Options");
        FindObjectOfType<AudioManager>().Play("MenuClick");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("MenuClick");
    }
}