using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundOverManager : MonoBehaviour
{
    PlayerConfiguration[] playerConfigs;

    public Text text;
    void Start()
    {
        playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        Debug.Log(playerConfigs.Length);
    }

    void Update()
    {
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            if (playerConfigs[i].isAlive)
            {
                Debug.Log("Round Over");
                text.text = "Player " + playerConfigs[i].playerIndex.ToString() + " Won the Round ! " + "the player's score is now " + playerConfigs[i].playerScore.ToString();
            }
        }
    }


    public void NextLevel()
    {
        SceneManager.LoadScene("Edwin");
    }
}
