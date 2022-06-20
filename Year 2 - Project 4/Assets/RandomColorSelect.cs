using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RandomColorSelect : MonoBehaviour
{
    public Button[] colorButtons;
    public PlayerConfiguration[] playerConfigs;
    public EventSystem eventSystem;
    public GameObject mainInputField;
    private int totalPlayerAmount;

    private Navigation inputFieldNavigation; // make global variable to avoid code repition 
    private void Awake()
    {
    //    inputFieldNavigation = mainInputField.GetComponent<InputField>().navigation;

    //    playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
    //    totalPlayerAmount = playerConfigs.Length - 1;

        Debug.Log(totalPlayerAmount);
        if (totalPlayerAmount == 0)
        {
            mainInputField.GetComponent<InputField>().navigation = ChangeNavigation(inputFieldNavigation, colorButtons[totalPlayerAmount]);
            eventSystem.firstSelectedGameObject = colorButtons[totalPlayerAmount].gameObject;
            colorButtons[totalPlayerAmount].gameObject.SetActive(true);
        }
        else if (totalPlayerAmount == 1)
        {
            mainInputField.GetComponent<InputField>().navigation = ChangeNavigation(inputFieldNavigation, colorButtons[totalPlayerAmount]);
            eventSystem.firstSelectedGameObject = colorButtons[totalPlayerAmount].gameObject;
            colorButtons[totalPlayerAmount].gameObject.SetActive(true);
        }
        else if (totalPlayerAmount == 2)
        {
            mainInputField.GetComponent<InputField>().navigation = ChangeNavigation(inputFieldNavigation, colorButtons[totalPlayerAmount]);
            eventSystem.firstSelectedGameObject = colorButtons[totalPlayerAmount].gameObject;
            colorButtons[totalPlayerAmount].gameObject.SetActive(true);

        }
        else if (totalPlayerAmount == 3)
        {
            mainInputField.GetComponent<InputField>().navigation = ChangeNavigation(inputFieldNavigation, colorButtons[totalPlayerAmount]); ChangeNavigation(inputFieldNavigation, colorButtons[totalPlayerAmount]);
            eventSystem.firstSelectedGameObject = colorButtons[totalPlayerAmount].gameObject;
            colorButtons[totalPlayerAmount].gameObject.SetActive(true);

        }
    }

    private Navigation ChangeNavigation(Navigation nav, Button button) // make method to avoid code repition 
    {
        nav.selectOnUp = button;
        nav.selectOnLeft = button;
        nav.selectOnRight = button;
        nav.selectOnDown = button;
        return nav;
    }
}
