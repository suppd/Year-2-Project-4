using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;

    public AudioClip shootSound;

    public float bulletForce = 15f;
    float fireRate = 1f;
    private float lastShot = 0.0f;
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

    public void Shoot(InputAction.CallbackContext context)
    {
        

        if (context.performed) 
        {
            
            if (Time.time > fireRate + lastShot)
            {
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

    }

}
