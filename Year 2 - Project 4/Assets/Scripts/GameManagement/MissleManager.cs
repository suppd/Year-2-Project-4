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

    private void Update()
    {
    }
    public void SpawnMissle()
    {
        //for(int i = 0; i < spawnPoints.Length; i++)
        foreach(Transform t in spawnPoints) 
        {
            
            Instantiate(missle, this.transform);
            gameObject.GetComponentInChildren<HomingMissle>().SetTarget(t.gameObject);

        }
        
    }
}
