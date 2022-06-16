using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;
    private List<HighScoreEntry> highScores;
    [SerializeField]
    private int maxPlayers = 2;
    public PlayerInputManager InputManager;
    public string sceneName = "LevelDesign1";
    //[SerializeField]
    //private GameObject playerPrefab;
    //[SerializeField]
    //private Transform[] playerSpawns;

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
            highScores = new List<HighScoreEntry>();
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigs()
    {
        return playerConfigs;
    }

    public List<HighScoreEntry> GetPlayerHighScores()
    {
        return highScores;
    }


    public void SetPlayerName(int i, string nameToSet)
    {
        playerConfigs[i].playerName = nameToSet;
        Debug.Log("Name: " + nameToSet + " Set To " + i);
    }

    public void SetPlayerSprite(int i, Sprite spriteToSet)
    {
        Debug.Log("Setting Sprite" + spriteToSet + "to player" + i);
        playerConfigs[i].playerSprite = spriteToSet;
    }

    public void SetAnimator(int i, AnimatorOverrideController animOverride)
    {
        playerConfigs[i].animatorOverrideController = animOverride;
    }

    public void SetTeam(int i, bool isBlue)
    {
        playerConfigs[i].isBlue = isBlue;
    }

    public void SetHighScoreEntry(int i, int score, string name)
    {
        highScores[i].score = score;
        highScores[i].playerName = name;
    }
    public void ReadyPlayer(int i)
    {
        //Debug.Log(playerConfigs.Count);
        //Debug.Log(i + "is ready");
        playerConfigs[i].isReady = true;
        if (playerConfigs.Count >= 2  && playerConfigs.All(p => p.isReady == true))
        {
            InputManager.DisableJoining();
            SceneManager.LoadScene(sceneName);
        }
    }

    public void HandlePlayerJoin(PlayerInput pInput)
    {
        Debug.Log("player joined" + pInput.playerIndex);
        pInput.transform.SetParent(transform);
        if (!playerConfigs.Any(p => p.playerIndex == pInput.playerIndex))
        {          
            playerConfigs.Add(new PlayerConfiguration(pInput));
            highScores.Add(new HighScoreEntry());
        }
    }

    public void HandleEasyPlayerJoin(PlayerInput pInput)
    {
        //Debug.Log("player joined" + pInput.playerIndex);
        //pInput.transform.SetParent(transform);
        //if (!playerConfigs.Any(p => p.playerIndex == pInput.playerIndex))
        //{
            //playerConfigs.Add(new PlayerConfiguration(pInput));
            //Instantiate(playerPrefab, playerSpawns[pInput.playerIndex]);
        //}
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
    //public HighScoreEntry HighScoreEntry { get; set; }
    public string playerName { get; set; }
    public int playerIndex { get; set; }
    public int playerScore { get; set; }
    public bool isReady { get; set; }

    public bool isBlue { get; set; }
    public bool isAlive{ get; set; }
    public Sprite playerSprite { get; set; }

    public AnimatorOverrideController animatorOverrideController { get; set; }

}
