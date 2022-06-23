using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEffects : MonoBehaviour
{
    public GameObject speedTrail;
    public void SpeedTrailOn()
    {
        speedTrail.SetActive(true);
    }

    public void SpeedTrailOff()
    {
        speedTrail.SetActive(false);
    }

}
