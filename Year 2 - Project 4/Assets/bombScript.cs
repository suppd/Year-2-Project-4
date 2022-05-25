using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public float fieldofImpact;

    public float force;

    public LayerMask LayerToHit;

    public GameObject explodeEffect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,fieldofImpact,LayerToHit);

        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            //obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }


        GameObject effect = Instantiate(explodeEffect, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(100);
            Explode();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Explode();
            Destroy(gameObject);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,fieldofImpact);
    }
}
