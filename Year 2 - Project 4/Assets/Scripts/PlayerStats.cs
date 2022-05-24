using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class PlayerStats : MonoBehaviour
{
    //static event Action<string> OnScoreChanged; 

    public float HP = 100;
    public float MaxHP = 100;

    public int score;
    public uint ID;
    

    Image HpBar;
    public GameObject player;
    public Animator anim;
    public GameObject myPrefab;

    public AudioClip EggSploded;

    private void Awake()
    {
        // UIObject.SetActive(false);
        HpBar = GetComponentInChildren<Image>();
        //Debug.Log(ID);
    }


    // The UI object gets set to false to be shown later
    public void TakeDamage(int damage)
    {        
        HP = HP - damage;
        
    }


    void Update()
    {
        //HpBar.fillAmount = (HP / MaxHP);

        if (HP <= 0)
        {
            Instantiate(myPrefab, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            // Invoke("KillPopUp", 5);
            Die();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
         
        }
    }

    public void IncreaseID()
    {
        ID = ID++;
    }

    public void Die()
    {
        // Instantiate(myPrefab, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
        Invoke("KillPopUp", 5);
        AudioSource.PlayClipAtPoint(EggSploded, transform.position);
        anim.SetBool("Death", true);
        Destroy(player);

    }

    public void KillPopUp()
    {
        Debug.Log("Perfect");
        //        Destroy(myPrefab);
    }
    

    
}
