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
    public Animator anim;
    public Vector2 movements;    public Vector2 inputVector;
    public Timer timer;
    public bool dashAllow;
    private bool isWalking;
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

                tr.emitting = true;
                
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
                tr.emitting = false;

                speed = nSpeed;
                isWalking = true;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Test")
        {
            if (dashAllow)
            {
                if (!isWalking)
                {
                    StartCoroutine(DashWall(collision));
                }
                else
                {
                    //collision.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    //GetComponent<CircleCollider2D>().enabled = true;
                }
            }


        }
    }

    IEnumerator DashWall(Collision2D wall)
    {
        //wall.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //yield return new WaitForSeconds(0.4f);
        //wall.gameObject.GetComponent<BoxCollider2D>().enabled = true;

        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        GetComponent<CircleCollider2D>().enabled = true;
    }


}
