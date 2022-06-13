using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissle : MonoBehaviour
{
    
    public float speed = 5f;
    public float rotateSpeed = 100f;
    [HideInInspector]
    public bool missleOn = false;

    public GameObject HomingEggsplosion;
    public GameObject targetGameObject;
    private Rigidbody2D rb;
    private int yourMom;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void FixedUpdate()
    {   
        Launch();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
    }
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
        Vector2 direction = (Vector2)targetGameObject.transform.position - rb.position;  

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotateSpeed;

        rb.velocity = transform.up * speed; 
    }
}
