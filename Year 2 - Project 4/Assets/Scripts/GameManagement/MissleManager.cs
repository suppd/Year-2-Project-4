using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleManager : MonoBehaviour
{
    public Transform[] targetPoints;
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
        foreach(Transform t in targetPoints) 
        {         
            GameObject newMissile = Instantiate(missle, this.transform);
            newMissile.GetComponent<HomingMissle>().SetTarget(t.gameObject);
        }
        
    }
}
