using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public GameObject levelSwitch;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Kaas");
            levelSwitch.SetActive(true);
        }    
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Playtest1");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Playtest2");
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene("Playtest3");
    }
}
