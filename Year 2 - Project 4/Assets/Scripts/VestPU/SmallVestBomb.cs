using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallVestBomb : MonoBehaviour
{
    public float fieldofImpact;
    public float force;
    public LayerMask PlayerToHit;
    public GameObject explodeEffect;
    public int damagePlayer = 100;
    public int damageEnemy = 10;


    private void Awake()
    {
        ExplodeSmall();
    }

    void ExplodeSmall()
    {
        Collider2D[] player = Physics2D.OverlapCircleAll(transform.position, fieldofImpact, PlayerToHit);

        foreach (CircleCollider2D obj2 in player)
        {
            Shooting shooting = obj2.GetComponent<Shooting>();
            if (shooting.vestDeployed)
            {
                obj2.gameObject.GetComponent<PlayerStats>().TakeDamage(damagePlayer);
                shooting.vestDeployed = false;
            }
            else
            {
                obj2.gameObject.GetComponent<PlayerStats>().TakeDamage(damageEnemy);
            }

        }
        GameObject effect = Instantiate(explodeEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 1f);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofImpact);
    }
}
