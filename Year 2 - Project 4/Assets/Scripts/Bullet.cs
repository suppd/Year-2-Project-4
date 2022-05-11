using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    float timer = 2;
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(bullet);
        }
    }
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
