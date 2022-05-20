using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

public class ManagePlayerInfo : MonoBehaviour
{
    public PlayerInputManager inputManager;

    public List<PlayerElements> players = new List<PlayerElements>();

    public void AddPlayerToList()
    {
        Debug.Log("Player Joined In Lobby");
    }
}
