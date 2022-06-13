using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidPickUp : MonoBehaviour
{

    public float duration = 3f;
    [SerializeField]
    private float newFireRate;

    public GameObject PUEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
            GameObject effect = Instantiate(PUEffect, transform.position, Quaternion.identity);
        }
    }

    IEnumerator PickUp(Collider2D player)
    {
        Shooting shooting = player.GetComponent<Shooting>();
        shooting.fireRate = newFireRate;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(duration);
        shooting.fireRate = 1f;
        Destroy(gameObject);
    }
}
