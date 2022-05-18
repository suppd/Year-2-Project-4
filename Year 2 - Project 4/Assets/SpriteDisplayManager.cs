using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpriteDisplayManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public Sprite[] sprites;
    public Animator[] animators;

    public List<PlayerElements> players = new List<PlayerElements>();

    //public Text score;
    public Transform[] texts;
    public void SetupPlayers(int i)
    {
        Debug.Log(i);
        spriteRenderer.sprite = sprites[i];
        animator = animators[i];
        //score.transform.localPosition = (transform.localPosition + new Vector3(500 * i, 0, 0));
        texts[i].gameObject.SetActive(true);
        players[i].id = i;

    } 
}
