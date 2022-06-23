using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleManager : MonoBehaviour
{
    public Transform[] targetPoints;
    public GameObject missle;
    private bool missleOn = true;
    public float timeStart;
    public Animator anim;
    public float timeAwake;
    public GameObject alertText;
    public Camera playerCam;
    private bool soundOn;

    private void Update()
    {
        
        timeStart -= Time.deltaTime;

        if (timeStart < Time.deltaTime)
        {
            if (!soundOn)
            {
                StartCoroutine(MissleLaunch());
                
            }
            anim.SetBool("Awake", true);
            SpawnMissle();
            missleOn = false;
        }

        if((timeStart + timeAwake) < Time.deltaTime)
        {
            anim.SetBool("Awake", false);
        }
    }


    IEnumerator MissleLaunch()
    {
        FindObjectOfType<AudioManager>().Play("MissleAnnouncement");
        soundOn = true;
        GameObject screenText = Instantiate(alertText, playerCam.transform);
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<AudioManager>().Play("MissleLaunch");

    }

    private void Start()
    {
        anim.SetBool("Awake", false);
    }

    private void Awake()
    {
        soundOn = false;

    }

    public void SpawnMissle()
    {
        if (missleOn)
        {
            foreach (Transform t in targetPoints)
            {
                t.gameObject.SetActive(true);
                GameObject newMissile = Instantiate(missle, this.transform);
                newMissile.GetComponent<HomingMissle>().SetTarget(t.gameObject);
            }
        }  
    }
}
