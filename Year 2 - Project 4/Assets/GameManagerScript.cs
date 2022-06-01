using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    PlayerConfigurationManager playerConfigurationManager;
    void Start()
    {
       playerConfigurationManager = GetComponent<PlayerConfigurationManager>();
    }

    void Update()
    {

    }
}
