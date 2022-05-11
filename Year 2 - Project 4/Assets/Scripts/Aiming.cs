using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aiming : MonoBehaviour
{
    public Transform player;
    public float radius;

    private Transform pivot;
    private float horizontal;
    private float vertical;
    private Vector3 position;

    void Start()
    {
        pivot = player.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
        //radius = pivot.localScale.x / 4;
    }

    void Update()
    {
        //position = new Vector3(horizontal, vertical, 0);
        //Vector3 orbVector = Camera.main.WorldToScreenPoint(player.position);
        //orbVector =  position- orbVector;
        float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;

        pivot.position = player.position;
        pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    public void Aim(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }
}