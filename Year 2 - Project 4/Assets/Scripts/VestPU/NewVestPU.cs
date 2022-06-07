using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewVestPU : MonoBehaviour
{

    [SerializeField]
    private GameObject VestEffect;
    

    public GameObject PUEffect;

    public float duration = 3f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
            GameObject effect = Instantiate(PUEffect, transform.position, Quaternion.identity);  
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        PlayerMovement speed = player.GetComponent<PlayerMovement>();
        Shooting stats = player.GetComponent<Shooting>();
        Animator anim = player.GetComponent<Animator>();
        
        anim.SetBool("Vest", true);
        stats.shotType = "vest";
        speed.bonusSpeed = 3f;
       

        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.activateTimer = true;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        if (stats.vestDeployed == false)
        {
            stats.SpawnSmallVest();
            anim.SetBool("Vest", false);
            speed.bonusSpeed = 0;
        }
        anim.SetBool("Vest", false);
        stats.shotType = "normal";
        speed.bonusSpeed = 0;
        stats.vestDeployed = false;
        Destroy(gameObject);
    }



}
