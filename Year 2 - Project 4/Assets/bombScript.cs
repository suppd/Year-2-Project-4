using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public float fieldofImpact;

    public float force;

    public LayerMask LayerToHit;
    public LayerMask PlayerToHit;
    public GameObject explodeEffect;

    void Start()
    {
        
    }

    void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position,fieldofImpact,LayerToHit);
        Collider2D[] player = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, PlayerToHit);
              
        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }
        foreach(CircleCollider2D obj2 in player)
        {
            obj2.gameObject.GetComponent<PlayerStats>().TakeDamage(100);
        }
        GameObject effect = Instantiate(explodeEffect, transform.position, Quaternion.identity);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            explode();
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {
            explode();
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,fieldofImpact);
    }
}
