using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public float HP = 100;
    public float MaxHP = 100;
    Image HpBar;
    public GameObject player;
    public Animator anim;
    public GameObject UIObject;

    private void Awake()
    {
        // UIObject.SetActive(false);
        HpBar = GetComponentInChildren<Image>();
    }


    // The UI object gets set to false to be shown later
    public void TakeDamage(int damage)
    {        
        HP = HP - damage;
        
    }


    void Update()
    {
        HpBar.fillAmount = (HP / MaxHP);

        if (HP <= 0)
        {
            UIObject.SetActive(true);
            Die();
        }
    }

    public void Die()
    {
        anim.SetBool("Death", true);
        Wait();
        Destroy(player);

    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        
        
    }
}
