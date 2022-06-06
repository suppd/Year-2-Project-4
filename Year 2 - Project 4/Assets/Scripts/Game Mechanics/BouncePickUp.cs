using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePickUp : MonoBehaviour
{
    public int numBounceBullets;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);

        }
    }

    void PickUp(Collider2D player)
    {
        Shooting stats = player.GetComponent<Shooting>();
        stats.shotType = "bounce";
        Destroy(gameObject);
    }
}
