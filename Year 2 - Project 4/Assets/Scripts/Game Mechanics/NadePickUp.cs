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
        }
    }

    void PickUp(Collider2D player)
    {
        Shooting stats = player.GetComponent<Shooting>();
        stats.shotType = "grenade";
        GameObject effect = Instantiate(PUEffect, transform.position, Quaternion.identity);    
        Destroy(gameObject);
    }
}
