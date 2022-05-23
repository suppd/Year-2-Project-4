using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls playercontrols;
    public float speed = 5f; //controls velocity multiplier
    public Rigidbody2D rb;
    public Animator anim;
    public Vector2 movements;    public Vector2 inputVector;
    public Timer timer;

    public float bonusSpeed = 0;
    public float DashForce = 20f;
    public float dashDistance = 0.2f;
    public float dashDuration = 0.5f;
    public float cooldownDuration = 1.0f;
    public ParticleSystem dashDust;

    public bool timeOn;
    
    private float dashCounter, dashCoolCounter;
    private float nSpeed = 5f;
    private float horizontal;
    private float vertical;
    private bool isfacingright = true;
    private bool isfacingleft = false;



    void Awake()
    {
        playercontrols = new PlayerControls();

    }

    void Update()
    {
        Movement();
        anim.SetFloat("Horizontal", inputVector.x);
        anim.SetFloat("Vertical", inputVector.y);
        anim.SetFloat("Speed", movements.SqrMagnitude());
        CheckDash();
        //CheckTimer();
    }
    public void SetInputVector(Vector2 vector)
    {
        inputVector = vector;
    }
    void Movement()
    {
        movements = new Vector2(inputVector.x, inputVector.y);
        rb.velocity = new Vector2(inputVector.x * (speed + bonusSpeed), inputVector.y * (speed + bonusSpeed));
    }



    public void Dashing(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (dashCounter <= 0 && dashCoolCounter <= 0)
            {
                anim.SetTrigger("Dash");

                speed = DashForce + bonusSpeed;

                dashCounter = dashDistance;

                CreateDust();
            }
        }
    }

    void CheckDash()
    {
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                speed = nSpeed;

                dashCoolCounter = dashDuration;
            }
        }

        if (dashCoolCounter > 0)

        {
            dashCoolCounter -= Time.deltaTime;

        }

    }

    void Flip()
    {
        isfacingright = !isfacingright;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    void CreateDust()
    {
        dashDust.Play();
    }

    //public void SpeedBoost()
    //{
    //    if (timer.timerOn)
    //    {
    //        bonusSpeed = 10f;
    //    }
    //    else
    //    {    //        bonusSpeed = 0;
    //    }
    //}
    //public void CheckTimer()

    //{
    //    timeOn = timer.timerOn;

    //}

}
