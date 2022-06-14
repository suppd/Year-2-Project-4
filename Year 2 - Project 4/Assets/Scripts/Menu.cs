using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public string level;
    public GameObject ButtonGameObject;
    public GameObject selectedObject;
    [SerializeField]
    private GameObject extendCasual;
    [SerializeField]
    private GameObject extendComp;

    [SerializeField]
    private GameObject CasualButtons;
    [SerializeField]
    private GameObject CompButtons;

    public void OnSelect(BaseEventData eventData)
    {
        FindObjectOfType<AudioManager>().Play("MenuHover");
        Debug.Log(this.ButtonGameObject.name + " was selected");

        if (eventData.selectedObject.gameObject.name == "Casual")
        {
            CompButtons.SetActive(false);
        }

        if (eventData.selectedObject.gameObject.name == "Competitive")
        {
            CasualButtons.SetActive(false);
        }

        if(eventData.selectedObject.name == "FreeForAllCasual" || eventData.selectedObject.name == "2vs2Casual")
        {
            extendCasual.SetActive(true);
        }
        else
        {
            extendCasual.SetActive(false);
        }

        if (eventData.selectedObject.name == "FreeForAllComp" || eventData.selectedObject.name == "2vs2Comp")
        {
            extendComp.SetActive(true);
        }
        else
        {
            extendComp.SetActive(false);
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log(this.ButtonGameObject.name + " was deselected");
    }

    public void Ready()
    {
        FindObjectOfType<AudioManager>().Play("Ready");
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
