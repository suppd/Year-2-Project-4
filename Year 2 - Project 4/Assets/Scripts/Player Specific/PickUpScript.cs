using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public float duration = 3f;
    public float bSpeed = 5f;
    private string currentPickUp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            currentPickUp = other.GetComponent<PickUpAbility>().mainPickUp;
            Exceptions(other);

            if (other.GetComponent<PickUpAbility>().ablePickUp)
            {
                other.GetComponent<PickUpAbility>().mainPickUp = "speed";
                StartCoroutine(PickUp(other));
                FindObjectOfType<AudioManager>().Play("PickUp");
            }
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        PlayerMovement speed = player.GetComponent<PlayerMovement>();
        speed.bonusSpeed = bSpeed;
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.TurnOff();
        playerStats.uiInfo = "speed";
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        speed.bonusSpeed = 0;
        player.GetComponent<PickUpAbility>().mainPickUp = "nothing";
        player.GetComponent<PickUpAbility>().CanPickUp();
        TimerUI vestTimer = player.gameObject.GetComponentInChildren<TimerUI>();
        vestTimer.DisableTimer();
        Destroy(gameObject);
    }

    void Exceptions(Collider2D player)
    {
        switch (currentPickUp)
        {
            case "grenade":
                //can
                player.GetComponent<PickUpAbility>().CanPickUp();
                break;
            case "bounce":
                //can
                player.GetComponent<PickUpAbility>().CanPickUp();
                break;
            case "dash":
                //can
                player.GetComponent<PickUpAbility>().CanPickUp();
                break;
            case "rapid":
                //can
                player.GetComponent<PickUpAbility>().CanPickUp();
                break;
            case "vest":
                //cannot
                player.GetComponent<PickUpAbility>().CannotPickUp();
                break;
            case "freeze":
                //can
                player.GetComponent<PickUpAbility>().CanPickUp();
                break;
            case "speed":
                //can
                player.GetComponent<PickUpAbility>().CanPickUp();
                break;
        }
    }
}
