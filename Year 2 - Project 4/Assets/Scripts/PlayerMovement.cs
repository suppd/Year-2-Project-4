using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls playerControls;
    public float speed = 10f; //Controls velocity multiplier
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
    private bool isFacingRight = true;
    private bool isFacingLeft = false;


    void Awake()
    {
        playerControls = new PlayerControls();

    }

    void Update()
    {
        Movement();
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);
        anim.SetFloat("Speed", movements.sqrMagnitude);
        Debug.Log(bonusSpeed);
        CheckDash();


    }

    void Movement()
    {
        movements = new Vector2(horizontal, vertical);
        rb.velocity = new Vector2(horizontal * (speed + bonusSpeed), vertical * (speed + bonusSpeed));

    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        //Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        //rb.rotation = angle;

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
        isFacingRight = !isFacingRight;
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
        timeOn = timer.timerOn;
    }
}
