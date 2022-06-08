using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissle : MonoBehaviour
{

    public Transform target;


    public float speed = 5f;
    public float rotateSpeed = 100f;
    [HideInInspector]
    public bool missleOn = false;

    public GameObject HomingEggsplosion;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Launch();
    }


    // void OnTriggerEnter2D ()
    // {
    //     Destroy(gameObject);
    //     Instantiate(HomingEggsplosion, transform.position, transform.rotation);       
    // }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bomba"))
        {
            Destroy(gameObject);
            Instantiate(HomingEggsplosion, transform.position, transform.rotation);       
        }
    }

 

    public void Launch()
    {
        // if (FireMissile)
        // {    
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed; 
        //}
    }
}
