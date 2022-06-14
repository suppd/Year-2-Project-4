using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public GameObject PUEffect;
    [SerializeField]
    private int healthGain = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PickUpAbility>().ablePickUp)
            {
                PickUp(other);
            }
        }
    }

    void PickUp(Collider2D player)
    {  
        GameObject effect = Instantiate(PUEffect, transform.position, Quaternion.identity);
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.GetHealth(healthGain);
        player.GetComponent<PickUpAbility>().CanPickUp();
        Destroy(gameObject);
    }
}
