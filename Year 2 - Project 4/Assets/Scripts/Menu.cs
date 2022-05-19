using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public Canvas optionsCanvas;

    private void Awake()
    {
        
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Designer Max", LoadSceneMode.Single);
    }

    public void Options(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            optionsCanvas.gameObject.SetActive(true);
        }
    }
}
