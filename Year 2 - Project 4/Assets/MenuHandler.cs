using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject leaderboard;
    [SerializeField] private GameObject leaderButton;
    [SerializeField] private GameObject leaderOpen;
    [SerializeField] private GameObject leaderClose;

    [SerializeField] private Button eggsplanationButton;
    [SerializeField] private GameObject backButton;

    public void Leaderboard()
    {
        if(leaderboard != null)
        {
            if (leaderboard.activeSelf)
            {
                leaderboard.SetActive(false);
                leaderOpen.SetActive(true);
                leaderButton.SetActive(true);
                leaderClose.SetActive(false);
            }
            else
            {
                leaderboard.SetActive(true);
                leaderOpen.SetActive(false);
                leaderButton.SetActive(false);
                leaderClose.SetActive(true);
            }
        }

        ClickSound();
    }

    public void Eggsplanation()
    {
        eggsplanationButton.onClick.Invoke();
        ClickSound();
    }

    public void Cancel()
    {
        backButton = GameObject.FindGameObjectWithTag("BackButton");

        if(backButton == null)
        {
            backButton = GameObject.Find("BackButton");
        }

        Debug.Log("Cancel");
        backButton.GetComponent<Button>().onClick.Invoke();
    }

    private void ClickSound()
    {
        FindObjectOfType<AudioManager>().Play("MenuClick");
    }
}
