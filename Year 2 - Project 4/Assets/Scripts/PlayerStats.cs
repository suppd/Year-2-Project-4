using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float HP = 100;
    public float MaxHP = 100;
    Image HpBar;

    private void Awake()
    {
        HpBar = GetComponentInChildren<Image>();
    }
    public void TakeDamage(int damage)
    {        
        HP -= damage;
        
    }

    private void Update()
    {
        HpBar.fillAmount = (HP / MaxHP);
    }
}
