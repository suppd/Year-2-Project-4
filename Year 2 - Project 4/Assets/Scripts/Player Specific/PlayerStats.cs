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

    public HealthBar healthBar;

    public SpriteRenderer sprite;

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

    //UI Icons PowerUps
    public GameObject eggsplosivePU;
    public GameObject bouncePU;
    public GameObject TimerVest;
    public GameObject freezePU;


    //Bools for turning on powerups
    public bool activate = false;
    public bool activate1 = false;
    public bool activate2 = false;

    public bool activateTimer = false;

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
        StartCoroutine(FlashRed());
    }

    public void GetHealth(int health)
    {
            HP = HP + health;
            currentHealth += health;
            if (HP > 100)
            {
                currentHealth = 100;
                HP = 100;
            }
            healthBar.SetHealth(HP);
    }


    void FixedUpdate()
    {
        if (HP <= 0)
        {
            Instantiate(myPrefab, new Vector3(player.transform.position.x, player.transform.position.y, -1), Quaternion.identity);
            // Invoke("KillPopUp", 5);
            level.amountOfPlayers--;
            Die();
            //level.UpdateAmountOfPlayers();
            
        }
        else if (level.amountOfPlayers == 1 && scored == false)
        {
            score+=1;
            playerConfig.playerScore = score;
            scored = true;
        }
        else if (HP >= 0)
        {
            playerConfig.isAlive=true;
        }
        Debug.Log(HP);


        if(activate == true)
        {
            eggsplosivePU.SetActive(true);
        }
        else
        {
            eggsplosivePU.SetActive(false);
        }

         if(activate1 == true)
        {
            bouncePU.SetActive(true);
        }
        else
        {
            bouncePU.SetActive(false);
        }

         if(activate2 == true)
        {
            freezePU.SetActive(true);
        }
        else
        {
            freezePU.SetActive(false);
        }

        if(activateTimer == true)
        {
            TimerVest.SetActive(true);
        }
        else
        {
            TimerVest.SetActive(false);
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
        //Destroy(myPrefab);
    }
    
    public void AssignPlayerConfig(PlayerConfiguration config)
    {
        playerConfig = config;
        ID = playerConfig.playerIndex;
        score = playerConfig.playerScore;
    }



    public IEnumerator FlashRed()
    {
        Color hitColor = new Vector4(1f, 0f, 0f, 0.6f);
        sprite.color = hitColor;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }
    
}
