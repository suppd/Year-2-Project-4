using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVestPU : MonoBehaviour
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
        Shooting stats = player.GetComponent<Shooting>();
        
        speed.startBombAnim();
        stats.shotType = "vest";
        speed.bonusSpeed = 3f; 
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        if (stats.vestDeployed == false)
        {
            Debug.Log("small");
            stats.SpawnSmallVest();
        }
        speed.StopBombAnim();
        stats.shotType = "normal";
        speed.bonusSpeed = 0;
        stats.vestDeployed = false;
        Destroy(gameObject);
    }



}
