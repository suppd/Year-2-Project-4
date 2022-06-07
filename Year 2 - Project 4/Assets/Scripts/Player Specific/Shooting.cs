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
    public AudioClip shootSound;
    public Animator anima;
    public string shotType;
    [HideInInspector]
    public bool vestDeployed = false;

    public float bulletForce = 15f;
    [SerializeField]
    float fireRate = 1f;
    private float lastShot = 0.0f;

    public bool isTeams;

    //public string shooter { get; set; }
    private void Awake()
    {
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
        switch (shotType)
        {
            case "normal":
                anima.SetTrigger("Shoot1");
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                lastShot = Time.time;
                break;
            case "grenade":
                anima.SetTrigger("Nade");
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                shotType = "normal";
                lastShot = Time.time;
                break;
            case "vest":
                SpawnVest();
                shotType = "normal";
                lastShot = Time.time;
                anima.SetBool("Vest", false);
                break;
            case "freeze":
                anima.SetTrigger("Freeze");
                SpawnFreeze();
                shotType = "normal";
                lastShot = Time.time;
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                break;
            case "bounce":
                anima.SetTrigger("Bounce");
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                lastShot = Time.time;
                shotType = "normal";
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
        //this.shooter = this.name;
        //bullet.GetComponent<Bullet>().shotFrom = shooter;
        ////Debug.Log(this.shooter);
        ////Debug.Log(bullet.GetComponent<Bullet>().shotFrom);       
    }

    void SpawnBomb()
    {
        GameObject Bomb = Instantiate(Bombprefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = Bomb.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
        PlayerStats playerStats = GetComponent<PlayerStats>();
        playerStats.activate = false;
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
    }

    void SpawnBounce()
    {
        GameObject bounce = Instantiate(bouncePrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bounce.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
