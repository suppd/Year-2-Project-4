using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsManager : MonoBehaviour
{
    PlayerConfiguration[] playerConfigs;
    public Canvas canvas;
    public Text text;
    public GameObject prefab;

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
                UpdateScoreBoard(playerConfigs[i].playerScore, i, playerConfigs[i].playerIndex, true);
                Debug.Log("Round Over");
                text.text = "Player " + playerConfigs[i].playerIndex.ToString() + " Won Game Round ! " + "the player's score is now " + playerConfigs[i].playerScore.ToString();
                PlayerConfigurationManager.Instance.SetHighScoreEntry(i, playerConfigs[i].playerScore, playerConfigs[i].playerName);
            }
            else if (!playerConfigs[i].isAlive)
            {
                PlayerConfigurationManager.Instance.SetHighScoreEntry(i, playerConfigs[i].playerScore, playerConfigs[i].playerName);
                Debug.Log("Added Score for player " + playerConfigs[i].playerIndex);
                AddScoreBoard();
                UpdateScoreBoard(playerConfigs[i].playerScore, i, playerConfigs[i].playerIndex, false);
            }
            numberOfPlayers++;
        }
    }
    public void AddScoreBoard()
    {
        var board = Instantiate(prefab, new Vector3(canvas.transform.position.x, canvas.transform.position.y - (75 * numberOfPlayers), canvas.transform.position.z), canvas.transform.rotation, canvas.transform);
        scores.Add(board);
    }
    public void UpdateScoreBoard(int score, int boardInstance, int playerIndex, bool wasAlive)
    {
        scores[boardInstance].GetComponent<ScoreBoard>().playerScore = score;
        scores[boardInstance].GetComponent<ScoreBoard>().playerIndex = playerIndex;
        scores[boardInstance].GetComponent<ScoreBoard>().wasAlive = wasAlive;
    }

    public void SaveScores()
    {
        //XMLManager.instance.SaveScores();
    }

    public void ToResultScreen()
    {
        SceneManager.LoadScene("ResultScene");
    }

    public void MainMenu()
    {
        GameObject configManager = GameObject.FindGameObjectWithTag("GameController");
        Destroy(configManager);
        SceneManager.LoadScene("Main Menu");
    }
}
