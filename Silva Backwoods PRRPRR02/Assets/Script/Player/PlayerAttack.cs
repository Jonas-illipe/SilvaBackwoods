using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int atkDamage;
    public float atkRange;
    public LayerMask enemies;
    public Transform atkPoint;

    private float timeBtwAtk;
    public float baseTimeBtwAtk;


    // Start is called before the first frame update
    void Start()
    {
        timeBtwAtk = baseTimeBtwAtk;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAtk <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Collider2D[] objectsToHit = Physics2D.OverlapCircleAll(atkPoint.position, atkRange, enemies);
                timeBtwAtk = baseTimeBtwAtk;
                for (int i = 0; i < objectsToHit.Length; i++)
                {
                    objectsToHit[i].GetComponent<EnemyManager>().TakeDamage(atkDamage);
                }
            }
        }
        else
        {
            timeBtwAtk -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atkPoint.position, atkRange);
    }
}
