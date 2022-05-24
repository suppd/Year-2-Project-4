using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadePickUp : MonoBehaviour
{
    public float duration = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        Shooting stats = player.GetComponent<Shooting>();
    //    stats.dashAllow = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);

      //  stats.dashAllow = false;
        Destroy(gameObject);
    }
}
