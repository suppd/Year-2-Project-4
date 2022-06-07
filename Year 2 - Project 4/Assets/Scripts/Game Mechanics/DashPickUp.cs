using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPickUp : MonoBehaviour
{

    public float duration = 3f;

    public GameObject PUEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
            GameObject effect = Instantiate(PUEffect, transform.position, Quaternion.identity);  
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        PlayerMovement stats = player.GetComponent<PlayerMovement>();
        stats.dashAllow = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        stats.dashAllow = false;
        Destroy(gameObject);
    }
}
