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
    private bool setTimer;

    private int lastSpawnPoint;

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
            if (random != lastSpawnPoint)
            {
                if (spawnPoints[random].transform.childCount == 0)
                {
                    SpawnRandomPowerUp(random, GetRandomSpawn());
                    lastSpawnPoint = random;
                    waitingForSpawn = false;
                    setTimer = true;
                }
            }
        }
    }
    public void SpawnRandomPowerUp(int index, int powerUpToSpawn)
    {
        Instantiate(powerUps[powerUpToSpawn], spawnPoints[index]);
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

    private void Update()
    {
        WaitForSpawn();
        if (setTimer)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenPowerups)
            {
                waitingForSpawn = true;
                timer = 0;
                setTimer = false;
            }
        }
    }
}
