using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleManager : MonoBehaviour
{
    public Transform[] targetPoints;
    public GameObject missle;
    private bool missleOn = true;
    public float timeStart;

    private void Update()
    {
        timeStart -= Time.deltaTime;

        if (timeStart < Time.deltaTime)
        {
            SpawnMissle();
            missleOn = false;
        }
    }


    public void SpawnMissle()
    {
        if (missleOn)
        {
            foreach (Transform t in targetPoints)
            {
                t.gameObject.SetActive(true);
                GameObject newMissile = Instantiate(missle, this.transform);
                newMissile.GetComponent<HomingMissle>().SetTarget(t.gameObject);
            }
        }  
    }
}
