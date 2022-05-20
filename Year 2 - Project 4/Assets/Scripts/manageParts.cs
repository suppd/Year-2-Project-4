using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageParts : MonoBehaviour
{
    float timer;

    void Awake()
    {
        timer = 0.8f;
    }
// Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;

        if(timer < Time.deltaTime)
        {
            Debug.Log("hooii");
            Destroy(gameObject);
        }
    }
}
