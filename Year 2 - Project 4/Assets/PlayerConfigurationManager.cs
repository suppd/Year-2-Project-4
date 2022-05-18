using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;

    [SerializeField]
    private int maxPlayers = 2;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Trying to create another instance of singleton");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
    }

    public void SetPlayerSprite(int index, Sprite spriteToSet)
    {
        playerConfigs[index].playerSprite = spriteToSet;
    }

    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if (playerConfigs.Count == maxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            SceneManager.LoadScene("Designer Max");
        }
    }

    public void HandlePlayerJoin(PlayerInput pInput)
    {
        Debug.Log("player joined" + pInput.playerIndex);        
        if(playerConfigs.Any(p => p.playerIndex == pInput.playerIndex))
        {
            pInput.transform.SetParent(transform);
            playerConfigs.Add(new PlayerConfiguration(pInput));
        }
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput p1)
    {
        playerIndex = p1.playerIndex;
        //Input = p1;
    }
    public PlayerInput playerInput { get; set; }
    public int playerIndex { get; set; }

    public bool isReady { get; set; }

    public Sprite playerSprite { get; set; }
}
