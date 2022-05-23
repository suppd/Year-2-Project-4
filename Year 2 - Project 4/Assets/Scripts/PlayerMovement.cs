using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls playercontrols;
    public float speed = 10f; //controls velocity multiplier
    public Rigidbody2D rb;
    public Animator anim;
    public Vector2 movements;
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
        anim.SetFloat("Horizontal", inputvector.x);
        anim.SetFloat("Speed", movements.SqrMagnitude());



        CheckDash();
        //CheckTimer();
    }
    public void SetInputVector(Vector2 vector)
    {
        inputvector = vector;
    }
    void Movement()
    {

        movements = new Vector2(inputvector.x, inputvector.y);
        rb.velocity = new Vector2(inputvector.x * (speed + bonusspeed), inputvector.y * (speed + bonusspeed));

    }



    public void Dashing(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (dashcounter <= 0 && dashcoolcounter <= 0)
            {
                anim.SetTrigger("Dash");

                speed = dashforce + bonusspeed;

                dashcounter = dashdistance;

                CreateDust();
            }
        }
    }

    void CheckDash()
    {
        if (dashcounter > 0)
        {
            dashcounter -= Time.deltaTime;
            if (dashcounter <= 0)
            {
                speed = nspeed;

                dashcoolcounter = dashduration;
            }
        }

        if (dashcoolcounter > 0)

        {
            dashcoolcounter -= Time.deltaTime;

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
        dashdust.Play();
    }

    public void SpeedBoost()
    {
        
        if (timer.timerOn)
        {
            bonusSpeed = 10f;
        }
        else
        {
            bonusSpeed = 0;
        }

    }
    public void CheckTimer()

    {
        timeon = timer.timerOn;

    }

}
