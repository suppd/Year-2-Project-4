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

    private int totalPlayerAmount;

    private void Awake()
    {
        playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        totalPlayerAmount = playerConfigs.Length;     
        
        if (totalPlayerAmount == 0)
        {
            eventSystem.firstSelectedGameObject = colorButtons[0].gameObject;
            colorButtons[totalPlayerAmount].gameObject.SetActive(true);
        }
        if (totalPlayerAmount == 1)
        {
            eventSystem.firstSelectedGameObject = colorButtons[1].gameObject;
            colorButtons[totalPlayerAmount].gameObject.SetActive(true);
        }
        if (totalPlayerAmount == 2)
        {
            eventSystem.firstSelectedGameObject = colorButtons[2].gameObject;
            colorButtons[totalPlayerAmount].gameObject.SetActive(true);
        }
        if (totalPlayerAmount == 3)
        {
            eventSystem.firstSelectedGameObject = colorButtons[3].gameObject;
            colorButtons[totalPlayerAmount].gameObject.SetActive(true);
        }
    }
}
