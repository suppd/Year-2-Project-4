using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteDisplayManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite[] sprites;
    public void ChangeSprite(int i)
    {
        Debug.Log(i);
        spriteRenderer.sprite = sprites[i];
    }
}
