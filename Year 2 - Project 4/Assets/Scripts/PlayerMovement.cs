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

    public float DashForce = 20f;
    public float dashDistance = 0.2f;
    public float dashDuration = 0.5f;
    public float cooldownDuration = 1.0f;

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

        movements = new Vector2(horizontal, vertical);
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Speed", movements.sqrMagnitude);
     
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
    
}
