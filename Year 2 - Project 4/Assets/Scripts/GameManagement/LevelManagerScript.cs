using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    private GameObject[] players;

    private float timer = 3f;
    public int UpdateAmountOfPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length);
        return players.Length;
    }

    private void Update()
    {
        //InvokeRepeating("UpdateAmountOfPlayers", 2, 0);
        if (players.Length == 0 || players == null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("RoundOver");
            }
        }
        else if (players.Length == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("RoundOver");
            }
        }
    }
}
