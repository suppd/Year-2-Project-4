using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerScript : MonoBehaviour
{
    public Transform hpBarsManager;
    public PlayerInputManager playerInputManager;
    List<Transform> hpBars = new List<Transform>();
    List<Transform> players = new List<Transform>();

    private void Awake()
    {
        //foreach(Transform child in hpBarsManager)
        //{
        //    hpBars.Add(child);
        //}
        
        //playerInputManager.onPlayerJoined


    }
}
