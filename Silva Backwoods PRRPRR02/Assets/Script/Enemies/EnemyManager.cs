using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Health")]
    public int currentHealth;
    public int maxHealth;

    [Header("Attacks")]
    public int damage;
    public Transform meleePoint;
    public float meleeRadius;
    protected bool playerDetected;
    public float baseTimeBtwAtk;
    private float timeBtwAtk;

    [Header("Movement")]
    public float moveSpeed;
    public float stoppDistance;

    [Header("Player")]
    protected Rigidbody2D rb;
    protected GameObject player;
    public LayerMask playerLayer;
    protected Transform playerLocation;

    [Header("Tracking")]
    public float locateRadius;
    public Transform locatePoint;
    

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLocation = player.GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        timeBtwAtk = baseTimeBtwAtk;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        playerDetected = Physics2D.OverlapCircle(locatePoint.position, locateRadius, playerLayer);
        
        if (playerDetected == true)
        {
            //Debug.Log("PlayerDetection Is True");
            FollowPlayer();
        }

        if (timeBtwAtk <= 0)
        {
            if (Physics2D.OverlapCircle(meleePoint.position, meleeRadius, playerLayer))
            {
                Debug.Log("Melee Detection Working");
                timeBtwAtk = baseTimeBtwAtk;
                MeleeAttack();
            }
        }
        else
        {
            timeBtwAtk -= Time.deltaTime;
        }
    }

    void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, playerLocation.position) > stoppDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerLocation.position, moveSpeed * Time.deltaTime);
        }
    }

    void MeleeAttack()
    {
        Collider2D[] objectsToHit = Physics2D.OverlapCircleAll(meleePoint.position, meleeRadius, playerLayer);
            
        for (int i = 0; i < objectsToHit.Length; i++)
        {
            objectsToHit[i].GetComponent<PlayerHealth>().TakeDamage(damage);
        }
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(locatePoint.position, locateRadius);
        Gizmos.DrawWireSphere(meleePoint.position, meleeRadius);
    }
}
