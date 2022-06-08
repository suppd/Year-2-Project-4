using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float[] percentages;
    public GameObject[] powerUps;

    public float timeBetweenPowerups;

    private Transform[] emptyPoints;
    private bool waitingForSpawn = true;

    private float timer;
    private float amount;
    private void Start()
    {
        emptyPoints = new Transform[spawnPoints.Length]; // ?

        amount = 1;
    }

    public void WaitForSpawn()
    {
        if (waitingForSpawn)
        {
            int random = Random.Range(0, spawnPoints.Length);
            if (spawnPoints[random].transform.childCount == 0)
            {
                SpawnRandomPowerUp(random, GetRandomSpawn());
                waitingForSpawn = false;
            }
        }
    }

    public void SpawnRandomPowerUp(int index, int powerUpToSpawn)
    {
        Instantiate(powerUps[powerUpToSpawn], spawnPoints[index]);
        waitingForSpawn = true;
    }
    private int GetRandomSpawn()
    {
        float random = Random.Range(0, 1f);
        float numforAdding = 0;
        float total = 0;
        for (int i = 0; i < percentages.Length; i++)
        {
            total += percentages[i];
        }

        for (int i = 0; i < powerUps.Length; i++)
        {
            if (percentages[i] / total + numforAdding >= random)
            {
                return i;
            }
            else
            {
                numforAdding += percentages[i] / total;
            }
        }
        return 0;
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
