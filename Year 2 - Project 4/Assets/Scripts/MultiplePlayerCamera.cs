using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Experimental.Rendering.Universal;


[RequireComponent(typeof(Camera))]
public class MultiplePlayerCamera : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = .5f;

    public float maxZoom = 40f;
    public float minZoom = 10f;
    public float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;
    private GameObject[] players;
    public bool lerp = false;
    PixelPerfectCamera perfectCamera;
    

    void Start()
    {
        cam = GetComponent<Camera>();
        perfectCamera = GetComponent<PixelPerfectCamera>();
    }

    void FixedUpdate()
    {
        if (targets.Count == 0)
            return;
        
        Move();
        Zoom();
    }

    void Zoom()
    {
        int newZoom = (int)Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        Debug.Log(newZoom);
        //cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
        if (lerp)
        {
            perfectCamera.assetsPPU = (int)Mathf.Lerp(perfectCamera.assetsPPU, newZoom, Time.deltaTime);
        }
        else if (!lerp)
        {
            perfectCamera.assetsPPU = newZoom;
        }
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
    private void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (targets.Count < players.Length)
            {
                targets.Add(player.transform);
            }
        }
    }
}