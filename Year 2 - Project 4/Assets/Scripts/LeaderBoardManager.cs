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
        bestScores = highScores.OrderByDescending(s => s.score).Take(5).ToList();

        for (int i = 0; i < bestScores.Count; i++)
        {
            Debug.Log("CheckingScores");
            AddScoreBoard();
            UpdateScoreBoard(bestScores[i].score, i, bestScores[i].playerName, bestScores[i].playerIcon);
        }
    }

    public void AddScoreBoard()
    {
        Debug.Log("Added");
        var board = Instantiate(scoreText, new Vector3(Panel.transform.position.x, Panel.transform.position.y - (7 * (Screen.height/100) * numberOfBoards), Panel.transform.position.z), Panel.transform.rotation, Panel.transform);
        textObjects.Add(board);
        numberOfBoards++;
    }
    public void UpdateScoreBoard(int score, int boardInstance, string playerName, int spriteId)
    {
        Debug.Log("Updated");
        textObjects[boardInstance].GetComponent<LeaderBoardPanel>().playerName = playerName;
        textObjects[boardInstance].GetComponent<LeaderBoardPanel>().playerScore = score;
        textObjects[boardInstance].GetComponent<LeaderBoardPanel>().spriteId = spriteId;
    }
}
