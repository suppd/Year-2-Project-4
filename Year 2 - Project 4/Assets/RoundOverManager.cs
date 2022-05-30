using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                text.text = "Player " + playerConfigs[i].playerIndex.ToString() + " Won the Round !" + "the players score is now" + playerConfigs[i].playerScore.ToString();
            }
        }
    }
}
