using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePickUp : MonoBehaviour
{
    public int numBounceBullets;

    public GameObject PUEffect;

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
        GameObject effect = Instantiate(PUEffect, transform.position, Quaternion.identity);  

        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.activate1 = true;
        playerStats.activate = false;
        playerStats.activate2 = false;


        Destroy(gameObject);
    }
}
