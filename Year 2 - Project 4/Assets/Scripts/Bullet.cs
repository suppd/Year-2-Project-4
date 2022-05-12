using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject hitEffect;

    public AudioClip crackEgg;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(15);
            Debug.Log("shot other player");
            //Destroy(gameObject);

        }

        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player")
        {

            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(crackEgg, transform.position);
            Destroy(effect, 1f);
            Destroy(gameObject);   
        }
    }
}
