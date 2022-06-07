using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public Text scoreText;

    public ScoreBoard(int _playerIndex, int _playerScore, bool _wasAlive)
    {
        playerIndex = _playerIndex;
        playerScore = _playerScore;
        wasAlive = _wasAlive;
    }

    public int playerIndex { get; set; }
    public int playerScore { get; set; }
    public bool wasAlive { get; set; }
    void Start()
    {
        scoreText.text = " Player " + playerIndex + " score is " + playerScore;
    }
}
