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
    public AudioClip hitPlayer;

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
            AudioSource.PlayClipAtPoint(hitPlayer, transform.position);
            Destroy(gameObject);
            Debug.Log("shot other player");

        }

        if (collision.gameObject.tag == "Wall")
        {
            numBounce++;
            bounceDamage += addedDamage;
            var speed = lastVel.magnitude;
            var direction = Vector2.Reflect(lastVel.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
            if (numBounce == maxBounce)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
                Destroy(gameObject);
                AudioSource.PlayClipAtPoint(crackEgg, transform.position);
                
            }

        }

        if (collision.gameObject.tag == "Bomba")
        {

            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(crackEgg, transform.position);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
