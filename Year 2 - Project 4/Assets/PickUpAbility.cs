using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbility : MonoBehaviour
{
    public bool ablePickUp;

    private void Awake()
    {
        ablePickUp = true;
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
