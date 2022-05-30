using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public GameObject Bombprefab;
    public GameObject vestPrefab;
    public AudioClip shootSound;
    public Animator anima;
    public bool nadeOn;
    public string shotType;

    public float bulletForce = 15f;
    [SerializeField]
    float fireRate = 1f;
    private float lastShot = 0.0f;

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
                StartCoroutine(DiffShooting());
            }
        }
    }
        
    IEnumerator DiffShooting()
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
                anima.SetBool("Vest", false);
                shotType = "normal";
                lastShot = Time.time;
                break;
            case "next":
                yield return new WaitForSeconds(0.15f);
                break;
        }
    }

    
    void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
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
        //this.shooter = this.name;
        //bullet.GetComponent<Bullet>().shotFrom = shooter;
        ////Debug.Log(this.shooter);
        ////Debug.Log(bullet.GetComponent<Bullet>().shotFrom);
    }
    void SpawnVest()
    {
        GameObject Vest = Instantiate(vestPrefab, FirePoint.position, FirePoint.rotation);
    }

}
