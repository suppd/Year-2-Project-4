using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public GameObject bouncePrefab;
    public GameObject Bombprefab;
    public GameObject vestPrefab;
    public GameObject smallVestPrefab;
    public GameObject freezePrefab;
    public Animator anima;
    public string shotType;
    public PlayerMovement playerMovement;

    [HideInInspector]
    public bool vestDeployed = false;

    public float bulletForce = 15f;
    [SerializeField]
    public float fireRate = 1f;
    private float lastShot = 0.0f;

    public bool isTeams;

    private PlayerStats playerStats;

    //public string shooter { get; set; }
    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        shotType = "normal";
    }
    public void Fire1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Time.time > fireRate + lastShot)
            {
                DiffShooting();
            }
        }
    }
        
    public void DiffShooting()
    {

        PlayerStats playerStats = GetComponent<PlayerStats>();
        switch (shotType)
        {

            case "normal":
                anima.SetTrigger("Shoot1");
                lastShot = Time.time;
                FindObjectOfType<AudioManager>().Play("Throw");
                break;
            case "grenade":
                anima.SetTrigger("Nade");
                shotType = "normal";
                lastShot = Time.time;
                playerStats.TurnOff();
                break;
            case "vest":
                SpawnVest();
                playerMovement.bonusSpeed = 0;
                shotType = "normal";
                lastShot = Time.time;
                anima.SetBool("Vest", false);
                playerMovement.vestOn = false;
                TimerUI vestTimer = GetComponentInChildren<TimerUI>();
                vestTimer.DisableTimer();
                playerStats.TurnOff();

                break;
            case "freeze":
                anima.SetTrigger("Freeze");
                shotType = "normal";
                lastShot = Time.time;
                //AudioSource.PlayClipAtPoint(shootSound, transform.position);
                playerStats.TurnOff();
                break;
            case "bounce":
                anima.SetTrigger("Bounce");
                lastShot = Time.time;
                shotType = "normal";
                playerStats.TurnOff();
                break;
        }
    }

    
    void SpawnBullet()
    {
        Debug.Log("s");
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        bullet.GetComponent<Bullet>().isBlue = gameObject.GetComponent<PlayerStats>().isBlue;
        bullet.GetComponent<Bullet>().isTeams = isTeams; //change this to a stored value on like playerstats which has isTeams stored and gets set to true / false depending on init
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);   
    }

    void SpawnBomb()
    {
        GameObject Bomb = Instantiate(Bombprefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = Bomb.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
        PlayerStats playerStats = GetComponent<PlayerStats>();
        
    }
     public void SpawnVest()
    {
        vestDeployed = true;
        GameObject vest = Instantiate(vestPrefab, this.transform.position, this.transform.rotation);
    }

    public void SpawnSmallVest()
    {
        vestDeployed = true;
        GameObject smallVest = Instantiate(smallVestPrefab, this.transform.position, this.transform.rotation);
    }

    public void SpawnFreeze()
    {
        GameObject freeze = Instantiate(freezePrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = freeze.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
        PlayerStats playerStats = GetComponent<PlayerStats>();
        
    }

    void SpawnBounce()
    {
        GameObject bounce = Instantiate(bouncePrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bounce.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
        PlayerStats playerStats = GetComponent<PlayerStats>();
        
    }
}
