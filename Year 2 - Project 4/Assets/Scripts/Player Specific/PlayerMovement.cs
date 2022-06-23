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
    public float DashForce = 20f;
    private bool isWalking;
    [HideInInspector]
    public bool vestOn;
    [HideInInspector]
    public bool dashAllow;
    [HideInInspector]
    public float bonusSpeed = 0;
    [HideInInspector]
    public Vector2 movements;
    [HideInInspector]
    public Vector2 inputVector;
    public float freezeDuration;

    public ParticleSystem dashDust;
    public float danceTimer = 0;
    private bool danceIsPlaying = false;
    private int dancePlaying = 0;

    private float slowAmount = 1f;
    private float dashCounter, dashCoolCounter;
    private float nSpeed = 5f;
    private float tSpeed;
    public float horizontal;
    private float vertical;
    private bool isfacingLeft = true;
    private float dashDistance = 0.2f;
    private float dashDuration = 0.5f;
    private float cooldownDuration = 1.0f;
    private bool isFrozen;

    void Awake()
    {
        anim.SetBool("Dancing0", false);
        playercontrols = new PlayerControls();
        dashAllow = false;
        vestOn = false;
        isFrozen = false;
    }

    void Update()
    {
        Movement();
        anim.SetFloat("Horizontal", rb.velocity.x);
        anim.SetFloat("Vertical", rb.velocity.y);
        anim.SetFloat("Speed", movements.SqrMagnitude());
        CheckDash();
        if (danceIsPlaying)
        {
            danceTimer += Time.deltaTime;
            if (danceTimer >= 2f)
            {
                ResetDance(dancePlaying);
            }
        }

        Debug.Log(danceIsPlaying);
        //Debug.Log(anim.GetBool("Dancing0"));
    }
 

    public void SetInputVector(Vector2 vector)
    {
        inputVector = vector;
    }

    public void DanceInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (anim.GetBool("Dancing0") == false)
            {
                Debug.Log("the paul");
                PlayDance(0);
                dancePlaying = 0;
            }
        }
    }
    public void NaeNaeInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("the naenae");
            PlayDance(1);
            dancePlaying = 1;
        }
    }
    public void FlagDanceInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("the flag");
            PlayDance(2);
            dancePlaying = 2;
        }
    }
    void PlayDance(int i)
    {        
        if (!danceIsPlaying)
        {
            Debug.Log("playing dance" + i);
            anim.SetBool("Dancing" + i, true);
            danceIsPlaying = true;
        }
    }
    void ResetDance(int i)
    {
        danceIsPlaying = false;
        danceTimer = 0;
        anim.SetBool("Dancing" + i, false);                 
    }
    void Movement()
    {
        tSpeed = (speed + bonusSpeed) * slowAmount;
        movements = new Vector2(inputVector.x, inputVector.y);
        rb.velocity = new Vector2(inputVector.x * (tSpeed), inputVector.y * (tSpeed));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulletWall")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<CircleCollider2D>());
        }
    }

        public void Dashing(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (!isFrozen)
            {
                if (dashCounter <= 0 && dashCoolCounter <= 0)
                {
                    if (!vestOn)
                    {
                        isWalking = false;
                        anim.SetTrigger("Dash");
                        if (dashAllow)
                        {
                            StartCoroutine(DashWall());
                        }
                        speed = DashForce;
                        dashCounter = dashDistance;
                        FindObjectOfType<AudioManager>().Play("Dash");
                        CreateDust();
                    }
                }
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

    IEnumerator Frozen(float slowPercent)
    {
        isFrozen = true;
        slowAmount = slowPercent;
        anim.SetBool("Frozen", true);
        yield return new WaitForSeconds(freezeDuration);
        isFrozen = false;
        anim.SetBool("Frozen", false);
        slowAmount = 1f;
        
    }

    public void StartFreeze(float slow)
    {
        StartCoroutine(Frozen(slow));
    }

   

}
