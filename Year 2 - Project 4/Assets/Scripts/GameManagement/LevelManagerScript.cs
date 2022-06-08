using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    private GameObject[] players;

    public int amountOfPlayers;
    private float timer = 2f;

    bool foundPlayers = false;
    private void Start()
    {
        
    }
    public int UpdateAmountOfPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length);
        amountOfPlayers = players.Length;
        return players.Length;
    }

    private void Update()
    {
        if (!foundPlayers)
        {
            Invoke("UpdateAmountOfPlayers", 0.5f);
            foundPlayers = true;
        }
        if (amountOfPlayers == 0 || players == null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("RoundOver");
            }
        }
        else if (amountOfPlayers == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("RoundOver");
            }
        }
    }
}
