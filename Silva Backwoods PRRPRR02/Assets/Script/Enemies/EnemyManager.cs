using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public int damage;

    public float moveSpeed;
    public float stoppDistance;

    protected Rigidbody2D rb;

    protected GameObject player;
    protected Transform playerLocation;
    public float locateRange;
    public Transform locatePoint;
    public LayerMask playerLayer;
    protected bool playerDetected;

    public Transform meleePoint;
    public float meleeRange;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLocation = player.GetComponent<Transform>();
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

        playerDetected = Physics2D.OverlapCircle(locatePoint.position, locateRange, playerLayer);
        /*if (Physics2D.OverlapCircle(locatePoint.position, locateRange, playerLayer))
        {
            playerDetected = Physics2D.OverlapCircle(locatePoint.position, locateRange, playerLayer);
            Debug.Log("PlayerDetected In OverlapCircle");
        }*/

        if (playerDetected == true)
        {
            Debug.Log("PlayerDetection Is True");
            FollowPlayer();
        }

        if (Physics2D.OverlapCircle(meleePoint.position, meleeRange, playerLayer))
        {
            Debug.Log("Melee Detection Working");
            MeleeAttack();
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
        Gizmos.DrawWireSphere(locatePoint.position, locateRange);
        Gizmos.DrawWireSphere(meleePoint.position, meleeRange);
    }
}
