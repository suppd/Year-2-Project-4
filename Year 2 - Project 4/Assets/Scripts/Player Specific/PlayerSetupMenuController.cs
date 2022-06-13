using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerSetupMenuController : MonoBehaviour
{
    private int playerIndex;
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private GameObject readyPanel;
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField]
    private Button readyButton;
    [SerializeField]
    private GameObject teamMenuPanel;
    [SerializeField]
    private EventSystem eventSystem;

    private float ignoreImputTime = 1.5f;
    private bool inputEnabled;

    public void SetPlayerIndex(int p1)
    {
        playerIndex = p1;
        titleText.SetText("Player" + (playerIndex +1).ToString());
        ignoreImputTime = Time.time + ignoreImputTime;
    }

    void Update()
    {
        if (Time.time > ignoreImputTime)
        {
            inputEnabled = true;
        }
    }

    public void SetSprite(Sprite sprite)
    {
        if (!inputEnabled) { return; }
        PlayerConfigurationManager.Instance.SetPlayerSprite(playerIndex, sprite);
        readyPanel.SetActive(true);
        readyButton.interactable = true;
        menuPanel.SetActive(false);
        readyButton.Select();
    }

    public void SetTeam(bool isBlue)
    {
        PlayerConfigurationManager.Instance.SetTeam(playerIndex, isBlue);
        readyPanel.SetActive(true);
        readyButton.interactable = true;
        teamMenuPanel.SetActive(false);
        readyButton.Select();

    }
    public void SetAnimator(AnimatorOverrideController animatorOverrideController)
    {
        PlayerConfigurationManager.Instance.SetAnimator(playerIndex, animatorOverrideController);
    }

    public void ReadyPlayer()
    {
        if(!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.ReadyPlayer(playerIndex);
        readyButton.gameObject.SetActive(false);
    }
}
