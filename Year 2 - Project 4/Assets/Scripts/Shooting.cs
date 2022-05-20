using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public AudioClip shootSound;
    public Animator anima;

    public float bulletForce = 15f;
    [SerializeField]
    float fireRate = 1f;
    private float lastShot = 0.0f;

    //public string shooter { get; set; }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    shoot();
        //}
    }

    public void Fire(InputAction.CallbackContext context)
    {

        if (context.performed) 
        {
            anima.SetTrigger("Shoot1");
        }
    }

    public void Fire2(InputAction.CallbackContext context)
    {

        if (context.performed)
        {

            if (Time.time > fireRate + lastShot)
            {
                anima.SetTrigger("Shoot2");
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                SpawnBullet();
                lastShot = Time.time;
            }

            //Debug.Log(FirePoint.position);
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

}
