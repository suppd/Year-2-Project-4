using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    private GameObject[] players;
    //for teams
    public bool teams = false;
    public PlayerConfiguration[] playerConfigs;

    private int amountOfPlayers;
    private float timer = 3f;

    public string levelName;
    bool foundPlayers = false;
    private void Awake()
    {
        playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
    }
    public int GetAmountOfPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(players.Length);
        amountOfPlayers = players.Length;
        return players.Length;
    }

    //Created this method for changing the local private variable amountOfPlayers instead of having a public variable
    public void UpdateAmountOfPlayers(int minus)
    {
        amountOfPlayers -= minus;
    }

    private void Update()
    {
        if (!foundPlayers)
        {
            //optimizied performance a bit by invoking this function only once at the start of the scene (only time nessicary and then it gets updated by the players later
            Invoke("GetAmountOfPlayers", 0.5f);
            foundPlayers = true;
        }
        if (amountOfPlayers == 0 || players == null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene(levelName);
            }
        }
        else if (amountOfPlayers == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene(levelName);
            }
        }
        else if (teams)
        {
           if (amountOfPlayers == 2)
            {
                for (int i = 0; i < amountOfPlayers; i++)
                {
                    if (playerConfigs[i].isBlue && playerConfigs[i].isAlive)
                    {
                        playerConfigs[i].playerScore += 1;
                        Debug.Log("Team Survived in one piece");
                        SceneManager.LoadScene(levelName);
                    }
                }
            }
        }
    }
}
