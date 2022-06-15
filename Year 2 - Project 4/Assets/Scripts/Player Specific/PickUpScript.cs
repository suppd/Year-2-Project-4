using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public float duration = 3f;
    public float bSpeed = 5f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PickUpAbility>().ablePickUp)
            {
                StartCoroutine(PickUp(other));
                FindObjectOfType<AudioManager>().Play("PickUp");
            }   
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        player.GetComponent<PickUpAbility>().CannotPickUp();
        PlayerMovement speed = player.GetComponent<PlayerMovement>();
        speed.bonusSpeed = bSpeed;
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.TurnOff();
        playerStats.uiInfo = "speed";
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        speed.bonusSpeed = 0;
        player.GetComponent<PickUpAbility>().CanPickUp();
        TimerUI vestTimer = player.gameObject.GetComponentInChildren<TimerUI>();
        vestTimer.DisableTimer();
        
        Destroy(gameObject);
    }
}
