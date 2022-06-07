using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TrailRenderer tr;
    PlayerControls playercontrols;
    public float speed = 5f; //controls velocity multiplier
    public Rigidbody2D rb;
    public Animator anim;    public float DashForce = 20f;
    private bool isWalking;

    [HideInInspector]
    public bool dashAllow;
    [HideInInspector]
    public float bonusSpeed = 0;
    [HideInInspector]
    public Vector2 movements;    [HideInInspector]    public Vector2 inputVector;
    public ParticleSystem dashDust;
    private float dashCounter, dashCoolCounter;
    private float nSpeed = 5f;
    private float horizontal;
    private float vertical;
    private bool isfacingright = true;
    private bool isfacingleft = false;
    private float dashDistance = 0.2f;
    private float dashDuration = 0.5f;
    private float cooldownDuration = 1.0f;



    void Awake()
    {
        playercontrols = new PlayerControls();
        dashAllow = false;
    }

    void Update()
    {
        Movement();
        anim.SetFloat("Horizontal", inputVector.x);
        anim.SetFloat("Vertical", inputVector.y);
        anim.SetFloat("Speed", movements.SqrMagnitude());
        CheckDash();
        
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
                isWalking = false;
                anim.SetTrigger("Dash");
                if (dashAllow)
                {
                    StartCoroutine(DashWall());
                }
                
                speed = DashForce + bonusSpeed;

                dashCounter = dashDistance;
                //tr.emitting = true;
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
                isWalking = true;
                dashCoolCounter = dashDuration;
                //tr.emitting = false;
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

    IEnumerator DashWall()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        GetComponent<CircleCollider2D>().enabled = true;
    }



}
