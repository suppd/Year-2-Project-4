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



    public void Update()
    {
        timer-=Time.deltaTime;
        
        if(timer < Time.deltaTime)
        {
            PlayerStats playerStats = GetComponentInParent<PlayerStats>();
            playerStats.TurnOff();
        }
    }
}
