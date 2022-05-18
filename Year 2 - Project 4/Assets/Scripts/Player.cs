using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //AIMING
    [Header("Aiming Settings")] 
    public Transform dot;
    public float radius;

    private float horizontal;
    private float vertical;
    private Vector3 position;

    private float rotateSpeed;
    private float lastAngle;

    private bool aimStopped = false;
    //-------
    //MOVING
    [Header("Move Settings")]
    PlayerControls playerControlls;
    public float speed = 10f; //Controls velocity multiplier
    public Rigidbody2D rb;
    public Animator anim;
    public Vector2 movements;

    private float horizontalMov;
    private float verticalMov;
    //private bool isFacingRight = true;
    //private bool isFacingLeft = false;
    //-----------
    //SHOOTING
    [Header("Shooting Settings")]
    public Transform FirePoint;
    public GameObject bulletPrefab;

    public AudioClip shootSound;

    public float bulletForce = 15f;
    float fireRate = 1f;
    private float lastShot = 0.0f;
    //-------------

    void Awake()
    {
        playerControlls = new PlayerControls();
        SetupAiming();      
    }

    void Update()
    {
        HandleMoving();
        HandleAiming();
    }

    void SetupAiming()
    {
        dot = dot.transform;
        transform.position += Vector3.up * radius;
        //radius = pivot.localScale.x / 4;
    }
    void HandleAiming()
    {
        //if (aimStopped == false)
        //{
            

            float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;

            dot.position = dot.position;
            dot.rotation = Quaternion.AngleAxis(angle , Vector3.forward);
            lastAngle = angle;
            //Debug.Log(lastAngle);
        //}
        //if (aimStopped)
        //{
            //Debug.Log("Aiming Stopped");
            //pivot.rotation = Quaternion.AngleAxis(lastAngle - 90, Vector3.forward);
        //}
    }
    public void Aim(Vector2 context)
    {
        horizontal = context.x;
        vertical = context.y;
        
        //if (horizontal > 0 || vertical > 0)
        //{
        //    aimStopped = false;
        //}
        //else
        //{
        //    aimStopped = true;

        //}
    }
    void HandleMoving()
    {
        movements = new Vector2(horizontalMov, verticalMov);
        rb.velocity = new Vector2(horizontalMov * speed, verticalMov * speed);
        anim.SetFloat("Horizontal", horizontalMov);
        anim.SetFloat("Speed", movements.sqrMagnitude);
    }
    public void Move(Vector2 context)
    {
        horizontalMov = context.x;
        verticalMov = context.y;
    }

    public void Shoot()
    {
            if (Time.time > fireRate + lastShot)
            {
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                SpawnBullet();
                lastShot = Time.time;
            }
            //Debug.Log(FirePoint.position);
    }

    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, this.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
