using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public Text scoreText;

    public ScoreBoard(int _playerIndex, int _playerScore, bool _wasAlive, string _playerName)
    {
        playerIndex = _playerIndex;
        playerScore = _playerScore;
        wasAlive = _wasAlive;
        playerName = _playerName;
    }

    public int playerIndex { get; set; }
    public string playerName { get; set; }
    public int playerScore { get; set; }
    public bool wasAlive { get; set; }
    void Start()
    {
        scoreText.text = "  " + playerName + " score is " + playerScore;
    }
}
