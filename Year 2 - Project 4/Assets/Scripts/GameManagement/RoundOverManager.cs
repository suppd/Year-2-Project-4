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
    public Canvas canvas;
    public Text text;
    public GameObject prefab;
    public string Levelname = "LevelDesign2v2";

    private int numberOfPlayers = 0;
    private List<GameObject> scores = new List<GameObject>();
    List<HighScoreEntry> highScores;
    List<HighScoreEntry> previousHighScores;
    void Awake()
    {
        playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        for (int i = 0; i < playerConfigs.Length; i++)
        {
            if (playerConfigs[i].isAlive)
            {
                AddScoreBoard();
                UpdateScoreBoard(playerConfigs[i].playerScore, i, playerConfigs[i].playerIndex, true, playerConfigs[i].playerName);
                Debug.Log("Round Over");
                text.text = " " + playerConfigs[i].playerName.ToString() + " Won the Round ! " + "the player's score is now " + playerConfigs[i].playerScore.ToString();
                PlayerConfigurationManager.Instance.SetHighScoreEntry(i, playerConfigs[i].playerScore, playerConfigs[i].playerName);
                if (playerConfigs[i].playerScore >= 5)
                {
                    ToResultScreen();
                }
            }
            else if (!playerConfigs[i].isAlive)
            {
                PlayerConfigurationManager.Instance.SetHighScoreEntry(i, playerConfigs[i].playerScore, playerConfigs[i].playerName);
                Debug.Log("Added Score for player " + playerConfigs[i].playerName);
                AddScoreBoard();
                UpdateScoreBoard(playerConfigs[i].playerScore, i, playerConfigs[i].playerIndex, false, playerConfigs[i].playerName);
            }
            numberOfPlayers++;
        }
        Save();
    }
    void Save()
    {
        highScores = PlayerConfigurationManager.Instance.GetPlayerHighScores();
        //previousHighScores = XMLManager.instance.LoadScores();

        XMLManager.instance.SaveScores(highScores);
    }
    public void AddScoreBoard()
    {      
        var board = Instantiate(prefab,new Vector3(canvas.transform.position.x, canvas.transform.position.y - (75 * numberOfPlayers), canvas.transform.position.z), canvas.transform.rotation, canvas.transform);
        scores.Add(board);
    }
    public void UpdateScoreBoard(int score, int boardInstance, int playerIndex, bool wasAlive, string playerName)
    {

        scores[boardInstance].GetComponent<ScoreBoard>().playerName = playerName;
        scores[boardInstance].GetComponent<ScoreBoard>().playerScore = score;
        scores[boardInstance].GetComponent<ScoreBoard>().playerIndex = playerIndex;
        scores[boardInstance].GetComponent<ScoreBoard>().wasAlive = wasAlive;
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
