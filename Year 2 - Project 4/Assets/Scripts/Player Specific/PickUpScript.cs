using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
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
        PlayerMovement speed = player.GetComponent<PlayerMovement>();
        speed.bonusSpeed = 5f;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);

        speed.bonusSpeed = 0;

        Destroy(gameObject);
    }
}
