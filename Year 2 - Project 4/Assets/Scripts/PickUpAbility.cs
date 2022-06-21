using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbility : MonoBehaviour
{
    public bool ablePickUp;
    public string mainPickUp;

    private void Awake()
    {
        mainPickUp = "nothing";
        ablePickUp = true;
    }

    public void MainPickUp()
    {
        switch (mainPickUp)
        {
            case "nothing":

                break;
            case "vest":

                break;
            case "grenade":

                break;
            case "bounce":

                break;
            case "dash":

                break;
            case "rapid":

                break;
            case "speed":

                break;
            case "freeze":

                break;
        }
    }

    public void CanPickUp()
    {
        ablePickUp = true;
    }

    public void CannotPickUp()
    {
        ablePickUp = false;
    }
}
