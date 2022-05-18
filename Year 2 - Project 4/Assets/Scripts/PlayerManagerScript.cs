using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class PlayerManagerScript : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public GameObject playerPrefab;
    public MultiplayerEventSystem[] multiplayerEventSystem;
    public Canvas[] canvases;

    public int numberOfPlayers;

    private void Awake()
    {
        //playerInputManager.onPlayerJoined;
        //playerPrefab.name = "Player";

    }

    // TODO: unsubscribe!

    public void OnPlayerJoined(PlayerInput player)
    {
        Debug.Log("player joined!");

        numberOfPlayers++;

        //playerPrefab.name = " " + numberOfPlayers.ToString();
        canvases[numberOfPlayers - 1].gameObject.SetActive(true);
        playerPrefab.GetComponent<PlayerInput>().uiInputModule = multiplayerEventSystem[numberOfPlayers - 1].GetComponent<InputSystemUIInputModule>();
        playerPrefab.GetComponent<SpriteDisplayManager>().SetupPlayers(numberOfPlayers - 1);
        

    }

    private void Update()
    {
    }
    // test/demo method:
    //public void ShowScoreChange(string playerName)
    //{
    //    Debug.Log(playerName + " scored a point");
    //}

}
