using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject missle;
    [HideInInspector]
    public int missleNum;


     void Start()
    {
        SpawnMissle();
    }

    public void SpawnMissle()
    {
        foreach(Transform t in spawnPoints) 
        {          
            Instantiate(missle, this.transform);
            gameObject.GetComponentInChildren<HomingMissle>().SetTarget(t.gameObject);
        }        
    }
}
