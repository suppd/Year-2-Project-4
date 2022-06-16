using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationUpdateScript : MonoBehaviour
{
    public void ChangeNavigation(Navigation nav, Button button) // make method to avoid code repition 
    {
        nav.selectOnUp = button;
        nav.selectOnLeft = button;
        nav.selectOnRight = button;
        nav.selectOnDown = button;
    }
}
