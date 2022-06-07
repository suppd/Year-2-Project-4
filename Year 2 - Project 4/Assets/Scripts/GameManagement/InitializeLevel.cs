using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField]
    private Transform[] playerSpawns;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private bool isTeams;

    private GameObject player;
    private PlayerConfiguration[] playerConfiguration;
    void Start()
    {
        playerConfiguration = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfiguration.Length; i++)
        {
            if (!isTeams)
            {
                //Debug.Log(playerConfiguration.Length);
                player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
                player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfiguration[i]);
                player.GetComponent<PlayerStats>().AssignPlayerConfig(playerConfiguration[i]);
                //camScript.targets[i] = player.transform;
            }
            if (isTeams)
            {
                
                if (i == 1 || i == 3)
                {
                    player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
                    player.GetComponent<PlayerStats>().isBlue = false;
                    player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfiguration[i]);
                    player.GetComponent<PlayerStats>().AssignPlayerConfig(playerConfiguration[i]);
                }
                else
                {
                    player = Instantiate(playerPrefab, playerSpawns[i].position, playerSpawns[i].rotation, gameObject.transform);
                    player.GetComponent<PlayerStats>().isBlue = true;
                    player.GetComponent<PlayerInputHandler>().InitializePlayer(playerConfiguration[i]);
                    player.GetComponent<PlayerStats>().AssignPlayerConfig(playerConfiguration[i]);
                }
            }
        }
    }
}
