using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NadePickUp : MonoBehaviour
{

    public GameObject PUEffect;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp(other);
            FindObjectOfType<AudioManager>().Play("PickUp");
        }
    }

    void PickUp(Collider2D player)
    {
        Shooting stats = player.GetComponent<Shooting>();
        stats.shotType = "grenade";
        GameObject effect = Instantiate(PUEffect, transform.position, Quaternion.identity);    
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.activate = true;
        playerStats.activate1 = false;
        playerStats.activate2 = false;

        Destroy(gameObject);
    }
}
