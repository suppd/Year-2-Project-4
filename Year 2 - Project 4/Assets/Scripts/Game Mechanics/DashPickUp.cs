using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPickUp : MonoBehaviour
{
    public float duration = 3f;

    public GameObject PUEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PickUpAbility>().ablePickUp)
            {
                StartCoroutine(PickUp(other));
                GameObject effect = Instantiate(PUEffect, transform.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("PickUp");
            }
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        player.GetComponent<PickUpAbility>().CannotPickUp();
        PlayerMovement stats = player.GetComponent<PlayerMovement>();
        stats.dashAllow = true;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.TurnOff();
        playerStats.uiInfo = "walldash";
        yield return new WaitForSeconds(duration);
        stats.dashAllow = false;
        player.GetComponent<PickUpAbility>().CanPickUp();
        TimerUI vestTimer = player.gameObject.GetComponentInChildren<TimerUI>();
        vestTimer.DisableTimer();
        

        Destroy(gameObject);
    }
}
