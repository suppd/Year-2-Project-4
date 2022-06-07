using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject[] powerUps;

    public float timeBetweenPowerups;

    private Transform[] emptyPoints;
    private bool waitingForSpawn = true;

    private float timer;
    private float amount;
    private void Start()
    {
        amount = 1;
    }

    public void WaitForSpawn()
    {
        if (waitingForSpawn)
        {
            int random = Random.Range(0, spawnPoints.Length);
            if (spawnPoints[random].transform.childCount == 0)
            {
                SpawnRandomPowerUp(random);
                waitingForSpawn = false;
            }
        }
    }

    public void SpawnRandomPowerUp(int index)
    {
        Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawnPoints[index]);
        waitingForSpawn = true;
    }

    void CheckEmptyPoints()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnPoints[i].transform.childCount == 0)
            {
                emptyPoints[i] = spawnPoints[i];
            }
            else
            {
                emptyPoints[i] = null;
            }
        }
    }

    private void Update()
    {
        //if (waitingForSpawn)
        //{
        //CheckEmptyPoints();
        InvokeRepeating("WaitForSpawn", timeBetweenPowerups, 0f);
        //}

        timer += Time.deltaTime;
        if (timer > timeBetweenPowerups)
        {
            waitingForSpawn = true;
            timer = 0;
        }
    }


}
