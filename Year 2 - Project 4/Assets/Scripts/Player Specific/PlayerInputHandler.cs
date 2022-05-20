using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig;
    private PlayerMovement mover;
    private Shooting shooter;
    private Aiming aimer;

    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Animator animator;

    private PlayerControls controls;

    private void Awake()
    {
        mover = GetComponent<PlayerMovement>();
        aimer = GetComponentInChildren<Aiming>();
        shooter = GetComponent<Shooting>();
        controls = new PlayerControls();
        animator = GetComponent<Animator>();
    }

    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;
        sprite.sprite = config.playerSprite;
        animator.runtimeAnimatorController = config.animatorOverrideController;
        config.playerInput.onActionTriggered += Input_onActionTriggered;
    }

    private void Input_onActionTriggered(CallbackContext obj)
    {
        if (obj.action.name == controls.Player.Move.name)
        {
            OnMove(obj);
        }
        if (obj.action.name == controls.Player.Fire.name)
        {
            OnShoot(obj);
        }
        if(obj.action.name == controls.Player.Look.name)
        {
            OnAim(obj);
        }
        //if (obj.action.name == controls.Player.Dash.name)
        //{
        //    OnDash(obj);
        //}
    }

    public void OnMove(CallbackContext context)
    {
        if (mover != null)
            mover.SetInputVector(context.ReadValue<Vector2>());
    }
    public void OnShoot(CallbackContext context)
    {
        if (shooter != null)
            shooter.Shoot(context);
    }
    public void OnAim(CallbackContext context)
    {
        if (aimer != null)
            aimer.SetInputVector(context.ReadValue<Vector2>());
        if (context.canceled)
        {
            aimer.SetAimingBool(true);
        }
        else if (context.started)
        {
            aimer.SetAimingBool(false);
        }
    }
}