using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public int damage;

    protected Rigidbody2D rb;

    protected GameObject player;
    public float locateRange;
    public LayerMask playerLayer;
    protected bool playerDetected = false;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        playerDetected = Physics2D.OverlapCircle(transform.position, locateRange, playerLayer);

        if (playerDetected == true)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {

    }

    void MeleeAttack()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

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
