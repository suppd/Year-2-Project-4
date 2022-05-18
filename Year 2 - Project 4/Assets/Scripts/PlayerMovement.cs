using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControlls playerControlls;
    public float speed = 5f; //Controls velocity multiplier
    public Rigidbody2D rb;
    public Animator anim;
    public Vector2 movements;

    public float DashForce = 20f;
    public float dashDistance = 0.2f;
    public float dashDuration = 0.5f;
    public float cooldownDuration = 1.0f;
    public ParticleSystem dashDust;

    private float dashCounter, dashCoolCounter;
    private float nSpeed = 5f;
    private float horizontal;
    private float vertical;
    private bool isFacingRight = true;
    private bool isFacingLeft = false;

    [SerializeField]

    private GameObject dashParticle;

    void Awake()
    {
        playerControlls = new PlayerControlls();

        //playerControlls.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();

        //playerControlls.Player.Move.canceled += ctx => mousePos = Vector2.zero;
    }

    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        movements = new Vector2(horizontal, vertical);
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Speed", movements.sqrMagnitude);

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                speed = nSpeed;
                dashCoolCounter = cooldownDuration;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        //if(!isFacingRight && horizontal > 0f)
        //{
        //    Flip(); 
        //}
        //else if (isFacingRight && horizontal < 0f)
        //{
        //    Flip();
        //}
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
                speed = DashForce;
                dashCounter = dashDistance;
                CreateDust();

            }
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
    
}
