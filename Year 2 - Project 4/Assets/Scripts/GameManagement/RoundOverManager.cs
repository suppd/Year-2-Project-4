using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundOverManager : MonoBehaviour
{
    PlayerConfiguration[] playerConfigs;
    public Canvas canvas;
    public Text text;
    public GameObject prefab;
    public string Levelname = "LevelDesign2v2";

    private int numberOfPlayers = 0;
    private List<GameObject> scores = new List<GameObject>();
    void Awake()
    {
        playerConfigs = PlayerConfigurationManager.Instance.GetPlayerConfigs().ToArray();
        //Debug.Log(playerConfigs.Length);

        for (int i = 0; i < playerConfigs.Length; i++)
        {
            if (playerConfigs[i].isAlive)
            {
                AddScoreBoard();
                UpdateScoreBoard(playerConfigs[i].playerScore, i, playerConfigs[i].playerIndex, true);
                Debug.Log("Round Over");
                text.text = "Player " + playerConfigs[i].playerIndex.ToString() + " Won the Round ! " + "the player's score is now " + playerConfigs[i].playerScore.ToString();
            }
            else if (!playerConfigs[i].isAlive)
            {
                Debug.Log("Added Score for player " + playerConfigs[i].playerIndex);
                AddScoreBoard();
                UpdateScoreBoard(playerConfigs[i].playerScore, i, playerConfigs[i].playerIndex, false);
            }
            numberOfPlayers++;
        }
    }
    public void AddScoreBoard()
    {      
        var board = Instantiate(prefab,new Vector3(canvas.transform.position.x, canvas.transform.position.y - (75 * numberOfPlayers), canvas.transform.position.z), canvas.transform.rotation, canvas.transform);
        scores.Add(board);
    }
    public void UpdateScoreBoard(int score, int boardInstance, int playerIndex, bool wasAlive)
    {
        scores[boardInstance].GetComponent<ScoreBoard>().playerScore = score;
        scores[boardInstance].GetComponent<ScoreBoard>().playerIndex = playerIndex;
        scores[boardInstance].GetComponent<ScoreBoard>().wasAlive = wasAlive;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(Levelname);
    }
}
