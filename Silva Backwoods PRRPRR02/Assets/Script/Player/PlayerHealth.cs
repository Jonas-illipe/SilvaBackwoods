using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void UpdateHealthSprites()
    {
       if (currentHealth > maxHealth)
       {
            currentHealth = maxHealth;
       } 

       for (int i = 0; i < hearts.Length; i++)
       {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
       }
    }

    public void Heal(int heal)
    {
        //if (ifall jonas äta mat få hp :D)
        UpdateHealthSprites();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        UpdateHealthSprites();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
