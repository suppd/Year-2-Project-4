using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisslePU : MonoBehaviour
{
    public GameObject missle;
    public Transform misslePoint;
    public float duration = 3f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        GameObject sendMissle = Instantiate(missle, misslePoint.position, misslePoint.rotation);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
