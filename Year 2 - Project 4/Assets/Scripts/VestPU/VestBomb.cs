using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VestBomb : MonoBehaviour
{
    public float fieldofImpact;
    public float force;
    public LayerMask LayerToHit;
    public LayerMask PlayerToHit;
    public GameObject explodeEffect;
    public bool explosionBig = true;
    

    private void Awake()
    {

            ExplodeBig();
         
    }
    void ExplodeBig()
    {
        
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, LayerToHit);
        Collider2D[] player = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, PlayerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

        foreach (CircleCollider2D obj2 in player)
        {
            CircleCollider2D dad = gameObject.GetComponentInParent<CircleCollider2D>();
            if(obj2 == dad)
            {
                dad.gameObject.GetComponent<PlayerStats>().TakeDamage(10);
            }
            else
            {
                obj2.gameObject.GetComponent<PlayerStats>().TakeDamage(100);
            }
            
        }
        GameObject effect = Instantiate(explodeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void ExplodeSmall()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, PlayerToHit);
        foreach (CircleCollider2D obj2 in player)
        {
            CircleCollider2D dad = gameObject.GetComponentInParent<CircleCollider2D>();
            if (obj2 == dad)
            {
                dad.gameObject.GetComponent<PlayerStats>().TakeDamage(100);
            }
            else
            {
                obj2.gameObject.GetComponent<PlayerStats>().TakeDamage(10);
            }

        }
        GameObject effect = Instantiate(explodeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
}
