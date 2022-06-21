using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour, ISelectHandler, IDeselectHandler, ICancelHandler
{
    public string level;
    [SerializeField]
    private GameObject backButton;

    public void OnSelect(BaseEventData eventData)
    {
        FindObjectOfType<AudioManager>().Play("MenuHover");

        Debug.Log(eventData.selectedObject.name + " was selected");
    }

    public void OnCancel(BaseEventData eventData)
    {
        backButton = GameObject.FindGameObjectWithTag("BackButton");
        Debug.Log("Cancel");
        eventData.selectedObject = backButton;
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
        GameObject configManager = GameObject.FindGameObjectWithTag("GameController");
        Destroy(configManager);
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
        GameObject configManager = GameObject.FindGameObjectWithTag("GameController");
        Destroy(configManager);
        Debug.Log("Quit");
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("MenuClick");
    }
}
