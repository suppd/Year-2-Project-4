using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePickUp : MonoBehaviour
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
        stats.shotType = "freeze";
        GameObject effect = Instantiate(PUEffect, transform.position, Quaternion.identity);
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        FindObjectOfType<AudioManager>().Play("Freeze");
        playerStats.activate2 = true;
        playerStats.activate = false;
        playerStats.activate1 = false;
        Destroy(gameObject);
    }
}
