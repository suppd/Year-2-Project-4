using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BouncingBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector3 lastVel;
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private GameObject killPlayer;
    private int numBounce = 0;
    [SerializeField]
    private int maxBounce = 2;
    public AudioClip crackEgg;

    private int bounceDamage = 25;
    public int addedDamage = 10;

    //public string shotFrom { get; set; }

    private void Awake()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lastVel = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject killEffect = Instantiate(killPlayer, transform.position, Quaternion.identity);
            Destroy(killEffect, 1f);
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(bounceDamage);
            FindObjectOfType<AudioManager>().Play("Bounce");
            Destroy(gameObject);

        }

        if (collision.gameObject.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("Bounce");
            numBounce++;
            bounceDamage += addedDamage;
            var speed = lastVel.magnitude;
            //float angle = Vector2.Angle(lastVel.normalized, collision.contacts[0].normal);
            var direction = Vector2.Reflect(lastVel.normalized, collision.contacts[0].normal);
            Debug.Log(direction);
            rb.velocity = direction * Mathf.Max(speed, 0f);
            transform.eulerAngles = Vector2.Reflect(lastVel.normalized, collision.contacts[0].normal);
            //transform.rotation = Quaternion.Euler(0,0, angle);
            if (numBounce == maxBounce)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(crackEgg, transform.position);
                FindObjectOfType<AudioManager>().Play("Bounce");
            }

        }

        if (collision.gameObject.tag == "Bomba")
        {

            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Bounce");
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
