using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        //Updates the health sprite depending on the amount of current hp.
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
        //If player eats apple heals 1 hp and then update healthsprites.
        currentHealth += heal;

        UpdateHealthSprites();
    }

    public void TakeDamage(int damage)
    {
        //If player takes damage -1 hp and then update healthsprites. If player took damage to 0 or below calls Die method.
        currentHealth -= damage;

        UpdateHealthSprites();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Destroys player object.
        Destroy(gameObject);
    }
}
