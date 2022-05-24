using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;

    public GameObject Bombprefab;
    public AudioClip shootSound;
    public Animator anima;

    public float bulletForce = 15f;
    [SerializeField]
    float fireRate = 1f;
    private float lastShot = 0.0f;

    //public string shooter { get; set; }

    public void Fire(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            if (Time.time > fireRate + lastShot)
            {
                anima.SetTrigger("Shoot1");
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                SpawnBomb();
                lastShot = Time.time;
            }
        }
    }



    public void Fire2(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            //anima.SetTrigger("Shoot1");
            if (Time.time > fireRate + lastShot)
            {
                anima.SetTrigger("Shoot2");
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                SpawnBomb();
                lastShot = Time.time;
            }
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

}
