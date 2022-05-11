using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(15);
            Debug.Log("shot other player");
            //Destroy(gameObject);

        }

        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
