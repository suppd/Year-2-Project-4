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

    private Button[] spriteButtons;

    private float ignoreImputTime = 1.5f;
    private bool inputEnabled;

    private void Start()
    {
        spriteButtons = GetComponentsInChildren<Button>();
        Debug.Log(spriteButtons.Length);
    }
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
        var configs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < configs.Length; i++)
        {
            if (configs[i].animatorOverrideController == animatorOverrideController)
            {
               // eventSystem.currentSelectedGameObject.SetActive(false);
                //for (int j = 0; j < spriteButtons.Length; j++)
                //{
                //    if (spriteButtons[j].GetComponent<PlayerSetupMenuController>().SetAnimator() == animatorOverrideController)
                //    {
                //        Debug.Log("same anim");
                //        spriteButtons[j].enabled = false;
                //    }
                //}
            }
            else
            {
                PlayerConfigurationManager.Instance.SetAnimator(playerIndex, animatorOverrideController);
            }
        }
    }
    public void ReadyPlayer()
    {
        if(!inputEnabled) { return; }

        PlayerConfigurationManager.Instance.ReadyPlayer(playerIndex);
        readyButton.gameObject.SetActive(false);

    }
}
