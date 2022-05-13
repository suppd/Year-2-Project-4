using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameObject floatingTextPrefab;
    public float HP = 100;
    public float MaxHP = 100;
    Image HpBar;
    public GameObject player;

    private void Awake()
    {
        HpBar = GetComponentInChildren<Image>();
    }
    public void TakeDamage(int damage)
    {        
        HP = HP - damage;
        
    }

    void ShowDamage(string text)
    {
        if(floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;

        }


    }

    void Update()
    {
        HpBar.fillAmount = (HP / MaxHP);

        if (HP <= 0)
        {
            ShowDamage(ToString());
            Die();
        }
    }

    public void Die()
    {
        Destroy(player);
    }
}
