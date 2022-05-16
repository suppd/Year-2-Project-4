using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{

    private float horizontal;
    private float vertical;
    public Vector2 movements;
    public Rigidbody2D rb;

    public float DashForce;
    public float dashDistance = 0.2f;
    public float dashDuration = 0.5f;
    public float cooldownDuration = 1.0f;
    private float dashCounter, dashCoolCounter;

    Coroutine _dashInProgress;

    bool isDashing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if(dashCounter <= 0)
            {
                dashCoolCounter = cooldownDuration;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    public void Dashing(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(dashCounter <= 0 && dashCoolCounter <= 0)
            {
                Debug.Log(DashForce);
                rb.AddForce(new Vector2(horizontal * DashForce, vertical * DashForce));
                //rb.velocity = new Vector2(horizontal * 100f, vertical * 100f);
                dashCounter = dashDistance;
            }

            
        }
            
           
     }
/*
    public bool TryDash(Vector2 direction)
    {
        if (_dashInProgress == null) return false;

        _dashInProgress = StartCoroutine(PerformDash(direction));

        return true;
    }

    IEnumerator PerformDash(Vector2 direction)
    {
        Vector2 targetVelocity = direction * dashDistance / dashDuration;
    }
*/
}
