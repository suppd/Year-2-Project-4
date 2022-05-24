using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehave : MonoBehaviour
{

    public float speed = 4;
    public Vector3 LaunchOffset;
    public bool Thrown;

    // Start is called before the first frame update
    void Start()
    {

        if (Thrown)
        {
        var direction = -transform.right + Vector3.up;
        GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        }
    transform.Translate(LaunchOffset);

    Destroy(gameObject, 5);

    }

    // Update is called once per frame
    void Update()
    {
        if(!Thrown)
        {
        transform.position += -transform.right * speed * Time.deltaTime; 
        }       
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
         
    // }
}
