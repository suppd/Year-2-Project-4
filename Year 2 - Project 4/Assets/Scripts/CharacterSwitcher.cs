using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    int index = 0;

    [SerializeField] List<GameObject> players = new List<GameObject>();
    PlayerInputManager playerInputManager;

    private void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        index = Random.Range(0, players.Count);
        playerInputManager.playerPrefab = players[index];
    }

    public void SwitchNextSpawnCharacter()
    {
        index = Random.Range(0, players.Count);
        playerInputManager.playerPrefab = players[index];
    }

}
