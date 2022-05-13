using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerControlls playerControlls;
    public float speed = 10f; //Controls velocity multiplier
    public Rigidbody2D rb;
    public Animator anim;
    public Vector2 movements;

    private float horizontal;
    private float vertical;
    private bool isFacingRight = true;
    private bool isFacingLeft = false;

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
        rb.velocity = new Vector2(horizontal * speed, vertical *speed);
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Speed", movements.sqrMagnitude);
      


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
