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
            if (other.GetComponent<PickUpAbility>().ablePickUp)
            {
                other.GetComponent<PickUpAbility>().mainPickUp = "freeze";
                PickUp(other);
                FindObjectOfType<AudioManager>().Play("PickUp");
            }
        }
    }

    void PickUp(Collider2D player)
    {
        player.GetComponent<PickUpAbility>().CannotPickUp();
        Shooting stats = player.GetComponent<Shooting>();
        stats.shotType = "freeze";
        GameObject effect = Instantiate(PUEffect, transform.position, Quaternion.identity);
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.TurnOff();
        playerStats.uiInfo = "freeze";
        Destroy(gameObject);
    }
}
