using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    public GameObject[] players;

    private float timer = 5f;
    public int UpdateAmountOfPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(players.Length);
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
    }
}
