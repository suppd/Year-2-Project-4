using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerScript : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public GameObject playerPrefab;

    public int numberOfPlayers;

    private void Awake()
    {
        //playerInputManager.onPlayerJoined;
    }

    public void OnPlayerJoined(PlayerInput player)
    {
        Debug.Log("player joined!");
        numberOfPlayers++;

      
        playerPrefab.GetComponent<SpriteDisplayManager>().ChangeSprite(numberOfPlayers -1);
        
    }

}
