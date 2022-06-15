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
    
    public Rigidbody2D rb;
    Vector3 lastVel;
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private GameObject killPlayer;

    public int damage = 25;

    public bool isTeams = false;
    public bool isBlue;
    public int shotID;

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
            if (!isTeams)
            {
                GameObject killEffect = Instantiate(killPlayer, transform.position, Quaternion.identity);
                Destroy(killEffect, 1f);
                collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
                Destroy(gameObject);
                Debug.Log("shot other player");
                FindObjectOfType<AudioManager>().Play("Hurt");
            }
            else if (isTeams)
            {
                if (collision.gameObject.GetComponent<PlayerStats>().isBlue && isBlue)
                {
                    Destroy(gameObject);
                    Debug.Log("shot teammate");
                }
                else if (!collision.gameObject.GetComponent<PlayerStats>().isBlue && isBlue)
                {
                    GameObject killEffect = Instantiate(killPlayer, transform.position, Quaternion.identity);
                    Destroy(killEffect, 1f);
                    collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
                    Debug.Log("shot other player");
                    Destroy(gameObject);        
                }
            }
        }

        else if(collision.gameObject.tag == "BulletWall" || collision.gameObject.tag == "Wall")
        {       
            var speed = lastVel.magnitude;
            var direction = Vector2.Reflect(lastVel.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);

            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("CrackEgg");
        }


        else if (collision.gameObject.tag == "Bomba")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("CrackEgg");
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("EggHit");
        }
    }
}
