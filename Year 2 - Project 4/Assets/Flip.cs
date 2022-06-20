using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{

    private bool isfacingLeft = true;
    public GameObject player;

    private void FixedUpdate()
    {

        if (player.GetComponent<PlayerMovement>().horizontal < 0 && !isfacingLeft)
        {
            FlipSprite();
        }
        if (player.GetComponent<PlayerMovement>().horizontal > 0 && isfacingLeft)
        {
            FlipSprite();
        }
        
    }

    void FlipSprite()
    {
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
        isfacingLeft = !isfacingLeft;
    }
}
