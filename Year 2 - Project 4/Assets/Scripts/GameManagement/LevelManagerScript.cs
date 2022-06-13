using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    private GameObject[] players;

    private int amountOfPlayers;
    private float timer = 3f;

    public string levelName;
    bool foundPlayers = false;
    public int GetAmountOfPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length);
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
            //optimizied preformance a bit by invoking this function only once at the start of the scene (only time nessicary and then it gets updated by the players later
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
    }
}
