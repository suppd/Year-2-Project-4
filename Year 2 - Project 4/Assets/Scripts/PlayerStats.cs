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
    public PlayerInput input;

    private void Awake()
    {
        ID = input.user.id;
        HpBar = GetComponentInChildren<Image>();
        //Debug.Log(ID);
    }
    public void TakeDamage(int damage)
    {        
        HP = HP - damage;
        
    }


    void Update()
    {
        //HpBar.fillAmount = (HP / MaxHP);

        if (HP <= 0)
        {
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
        Destroy(player);
    }

    
}
