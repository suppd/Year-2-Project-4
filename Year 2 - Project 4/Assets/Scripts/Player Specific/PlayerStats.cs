using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class PlayerStats : MonoBehaviour
{
    public int HP = 100;
    public int MaxHP = 100;
    public int currentHealth;




    public healthBaR healthBar;


    public int score { get; set; }
    public int ID;
   
    public GameObject player;
    public Animator anim;
    public GameObject myPrefab;

    public AudioClip EggSploded;
    public int num= 100;

    public bool isBlue = true;
    Camera cam;

    LevelManagerScript level;
    PlayerConfiguration playerConfig;

    private bool scored = false;

    private void Awake()
    {
        level = FindObjectOfType<LevelManagerScript>();
        cam = FindObjectOfType<Camera>();
    }

    void Start()
    {
        currentHealth = MaxHP;
        healthBar.SetMaxHealth(MaxHP);
    }

    public void TakeDamage(int damage)
    {        
        HP = HP - damage; 
        currentHealth -= damage;      

        healthBar.SetHealth(HP);
    }


    void Update()
    {
        if (HP <= 0)
        {
            Instantiate(myPrefab, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            // Invoke("KillPopUp", 5);           
            Die();
            level.UpdateAmountOfPlayers();
        }
        else if (level.UpdateAmountOfPlayers() == 1 && scored == false)
        {
            score+=1;
            playerConfig.playerScore = score;
            scored = true;
        }
        else if (HP >= 0)
        {
            playerConfig.isAlive=true;
        }
        //Debug.Log(HP);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void Die()
    {
        // Instantiate(myPrefab, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
        Invoke("KillPopUp", 5);
        AudioSource.PlayClipAtPoint(EggSploded, transform.position);
        anim.SetBool("Death", true);
        playerConfig.isAlive = false;
        cam.GetComponent<MultiplePlayerCamera>().targets.Remove(this.transform);
        Destroy(player);

    }

    public void KillPopUp()
    {
        Debug.Log("Perfect");
        //        Destroy(myPrefab);
    }
    
    public void AssignPlayerConfig(PlayerConfiguration config)
    {
        playerConfig = config;
        ID = playerConfig.playerIndex;
        score = playerConfig.playerScore;
    }
    
}
