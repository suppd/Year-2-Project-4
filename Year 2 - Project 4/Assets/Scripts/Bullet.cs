using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bullet : MonoBehaviour
{
    
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private GameObject killPlayer;

    public AudioClip crackEgg;
    public AudioClip hitPlayer;

    //public string shotFrom { get; set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject killEffect = Instantiate(killPlayer, transform.position, Quaternion.identity);
            Destroy(killEffect);
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(50);
            AudioSource.PlayClipAtPoint(hitPlayer, transform.position);
            Destroy(gameObject);
            Debug.Log("shot other player");           

        }

        if(collision.gameObject.tag == "Wall")
        {

            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(crackEgg, transform.position);
        }

        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
