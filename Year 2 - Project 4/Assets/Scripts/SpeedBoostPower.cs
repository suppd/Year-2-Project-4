using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPower : MonoBehaviour
{

    public float bonusSpeed = 20f;
    public Timer timer;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            timer.timerOn = true;
            collision.GetComponent<PlayerMovement>().SpeedBoost(bonusSpeed);
            
            //Debug.Log("speed boosting");
            Destroy(gameObject);
        }
    }
}
