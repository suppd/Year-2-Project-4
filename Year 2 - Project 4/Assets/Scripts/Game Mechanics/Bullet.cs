using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector3 lastVel;
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private GameObject killPlayer;

    public AudioClip crackEgg;
    public AudioClip hitPlayer;

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
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(25);
            AudioSource.PlayClipAtPoint(hitPlayer, transform.position);
            Destroy(gameObject);
            Debug.Log("shot other player");           

        }

        if(collision.gameObject.tag == "Wall")
        {
            /*
            Vector2 inDirection = GetComponent<Rigidbody2D>().velocity;
            Vector2 inNormal = collision.contacts[0].normal;
            Vector2 newVelocity = Vector2.Reflect(inDirection, inNormal);
            rb.velocity = newVelocity;
            Debug.Log(inNormal);
            */

            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(crackEgg, transform.position);
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
