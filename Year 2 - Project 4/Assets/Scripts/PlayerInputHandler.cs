using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    Player player;

    [SerializeField] List<GameObject> prefabs = new List<GameObject>();

    private void Start()
    {
       
        player = GameObject.Instantiate(prefabs[Random.Range(0, prefabs.Count)], transform.position,transform.rotation).GetComponent<Player>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (player)
        {
            player.Move(context.ReadValue<Vector2>());
            //Debug.Log("trying to move");
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (player && context.started)
        {
            player.Shoot();
        }
    }

    public void Aiming(InputAction.CallbackContext context)
    {
        if (player)
        player.Aim(context.ReadValue<Vector2>());
    }
}
