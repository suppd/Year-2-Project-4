using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AnimtorSelectController : MonoBehaviour
{
    private PlayerInput playerInput;
    private EventSystem eventSystem;

    private List<PlayerConfiguration> configs;

    private int ID;
    private void Awake()
    {
        configs = PlayerConfigurationManager.Instance.GetPlayerConfigs();
    }

    private void Update()
    {
        GetCurretPlayer();
    }
    public void GetCurretPlayer()
    {
        for (int i = 0; i < configs.Count; i++)
        {
            if (configs[i].playerInput.uiInputModule.submit.action != null)
            {
                ID = configs[i].playerIndex;
                Debug.Log(ID);
            }
        }
    }
    public void SetAnimator(AnimatorOverrideController animatorOverrideController)
    {
        PlayerConfigurationManager.Instance.SetAnimator(ID, animatorOverrideController);
    }

}
