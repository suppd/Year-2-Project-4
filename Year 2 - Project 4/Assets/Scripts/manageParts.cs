using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageParts : MonoBehaviour
{
    float timer;

    void Awake()
    {
        timer = 5;
    }
// Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;

        if(timer < Time.deltaTime)
        {
           Debug.Log("vest Timer");
           // Destroy(gameObject);
            PlayerStats playerStats = GetComponent<PlayerStats>();
            playerStats.activateTimer = false;
        }
    }
}
