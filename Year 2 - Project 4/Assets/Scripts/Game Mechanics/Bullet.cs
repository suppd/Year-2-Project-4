using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bullet : MonoBehaviour
{

    public Bullet(bool _isBlue, bool _isTeams)
    {
        isBlue = _isBlue;
        isTeams = _isTeams;
    }
    
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private GameObject killPlayer;

    public AudioClip crackEgg;
    public AudioClip hitPlayer;

    public bool isTeams = false;
    public bool isBlue;

    //public string shotFrom { get; set; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isTeams)
            {
                GameObject killEffect = Instantiate(killPlayer, transform.position, Quaternion.identity);
                Destroy(killEffect, 1f);
                collision.gameObject.GetComponent<PlayerStats>().TakeDamage(25);
                AudioSource.PlayClipAtPoint(hitPlayer, transform.position);
                Destroy(gameObject);
                Debug.Log("shot other player");
            }
            if (isTeams)
            {
                if (collision.gameObject.GetComponent<PlayerStats>().isBlue && isBlue)
                {
                    Destroy(gameObject);
                    Debug.Log("shot teammate");
                }
                else if (!collision.gameObject.GetComponent<PlayerStats>().isBlue && !isBlue)
                {
                    GameObject killEffect2 = Instantiate(killPlayer, transform.position, Quaternion.identity);
                    Destroy(killEffect2, 1f);
                    collision.gameObject.GetComponent<PlayerStats>().TakeDamage(25);
                    AudioSource.PlayClipAtPoint(hitPlayer, transform.position);
                    Destroy(gameObject);
                }
            }

        }

        if(collision.gameObject.tag == "Wall")
        {
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
