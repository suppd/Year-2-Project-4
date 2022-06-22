using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Xml;
using System.Linq;
using System.Xml.Linq;

public class RoundOverManager : MonoBehaviour
{
    PlayerConfiguration[] playerConfigs;
    public GameObject panel;
    public GameObject prefab;
    public string Levelname = "LevelDesign2v2";

    private int numberOfPlayers = 0;
    private List<GameObject> scores = new List<GameObject>();
    void Awake()
    {
        playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            if (playerConfigs[i].isAlive)
            {
                AddScoreBoard();
                UpdateScoreBoard(playerConfigs[i].playerScore, i, playerConfigs[i].playerIndex, true, playerConfigs[i].playerName, playerConfigs[i].playerSprite);
                Debug.Log("Round Over");              
                PlayerConfigurationManager.Instance.SetHighScoreEntry(i, playerConfigs[i].playerScore, playerConfigs[i].playerName,playerConfigs[i].spriteId);
                if (playerConfigs[i].playerScore >= PlayerConfigurationManager.Instance.maxAmountOfRounds)
                {
                    Debug.Log("Going Result Screen!");
                    ToResultScreen();
                }
            }
            else if (!playerConfigs[i].isAlive)
            {
                PlayerConfigurationManager.Instance.SetHighScoreEntry(i, playerConfigs[i].playerScore, playerConfigs[i].playerName,playerConfigs[i].spriteId);
                Debug.Log("Added Score for player " + playerConfigs[i].playerName);
                AddScoreBoard();
                UpdateScoreBoard(playerConfigs[i].playerScore, i, playerConfigs[i].playerIndex, false, playerConfigs[i].playerName, playerConfigs[i].playerSprite);
            }
            numberOfPlayers++;
        }
    }
    public void AddScoreBoard()
    {      
        var board = Instantiate(prefab,new Vector3(panel.transform.position.x, panel.transform.position.y - (120 * numberOfPlayers), panel.transform.position.z), panel.transform.rotation, panel.transform);
        scores.Add(board);
    }
    public void UpdateScoreBoard(int score, int boardInstance, int playerIndex, bool wasAlive, string playerName, Sprite playerIcon)
    {

        scores[boardInstance].GetComponent<ScoreBoard>().playerName = playerName;
        scores[boardInstance].GetComponent<ScoreBoard>().playerScore = score;
        scores[boardInstance].GetComponent<ScoreBoard>().playerIndex = playerIndex;
        scores[boardInstance].GetComponent<ScoreBoard>().wasAlive = wasAlive;
        scores[boardInstance].GetComponent<ScoreBoard>().playerIcon = playerIcon;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(Levelname);
    }

    public void ToResultScreen()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void MainMenu()
    {
        GameObject configManager = GameObject.FindGameObjectWithTag("GameController");
        Destroy(configManager);
        SceneManager.LoadScene("MainMenu");
    }
}
