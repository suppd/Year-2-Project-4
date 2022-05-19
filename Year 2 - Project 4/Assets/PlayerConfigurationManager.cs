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
            Debug.Log("[Singleton] Trying to create another instance of singleton");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public void SetPlayerSprite(int i, Sprite spriteToSet)
    {
        Debug.Log("Setting Sprite" + spriteToSet + "to player" + i);
        playerConfigs[i].playerSprite = spriteToSet;
    }

    public void ReadyPlayer(int i)
    {
        //Debug.Log(playerConfigs.Count);
        //Debug.Log(i + "is ready");
        playerConfigs[i].isReady = true;
        if (playerConfigs.Count == maxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            SceneManager.LoadScene("Designer Max");
        }
    }

    public void HandlePlayerJoin(PlayerInput pInput)
    {
        Debug.Log("player joined" + pInput.playerIndex);
        pInput.transform.SetParent(transform);
        if (!playerConfigs.Any(p => p.playerIndex == pInput.playerIndex))
        {          
            playerConfigs.Add(new PlayerConfiguration(pInput));
        }
    }
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput p1)
    {
        playerIndex = p1.playerIndex;
        playerInput = p1;
    }
    public PlayerInput playerInput { get; set; }
    public int playerIndex { get; set; }

    public bool isReady { get; set; }

    public Sprite playerSprite { get; set; }
}
