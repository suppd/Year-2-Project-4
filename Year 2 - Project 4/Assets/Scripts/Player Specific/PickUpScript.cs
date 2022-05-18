using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "PickUp")
            {
                //collision.GetComponent<PowerUp>().PowerUp1();
                Destroy(collision.gameObject);

            }
        }
    }
}
