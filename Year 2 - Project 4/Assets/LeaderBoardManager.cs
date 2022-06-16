using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class LeaderBoardManager : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject Panel;
    private List<HighScoreEntry> highScores = new List<HighScoreEntry>();
    private List<HighScoreEntry> bestScores = new List<HighScoreEntry>();

    private List<GameObject> textObjects = new List<GameObject>();

    private int numberOfBoards;
    private void Start()
    {
        highScores = XMLManager.instance.LoadScores();
        bestScores = highScores.Where(s => s.score > 2).Take(2).ToList();

        for (int i = 0; i < bestScores.Count; i++)
        {
            Debug.Log("CheckingScores");
            AddScoreBoard();
            UpdateScoreBoard(bestScores[i].score, i, bestScores[i].playerName);
        }
    }

    public void AddScoreBoard()
    {
        Debug.Log("Added");
        var board = Instantiate(scoreText, new Vector3(Panel.transform.position.x, Panel.transform.position.y - (75 * numberOfBoards), Panel.transform.position.z), Panel.transform.rotation, Panel.transform);
        textObjects.Add(board);
        numberOfBoards++;
    }
    public void UpdateScoreBoard(int score, int boardInstance, string playerName)
    {
        Debug.Log("Updated");
        textObjects[boardInstance].GetComponent<ScoreBoard>().playerName = playerName;
        textObjects[boardInstance].GetComponent<ScoreBoard>().playerScore = score;
    }
}
