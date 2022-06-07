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
        players = GameObject.FindGameObjectsWithTag("Player"); // done every update??!?!
        Debug.Log("Number of players: "+players.Length);
        return players.Length;
    }

    private void Update()
    {
        if (players.Length == 1)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("RoundOver");
            }
        }
        else if (players.Length == 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SceneManager.LoadScene("RoundOver");
            }
        }
    }
}
