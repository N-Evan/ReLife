using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDummy : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float attackTime;
    [SerializeField] private float attackCD;

    public Transform attackPos;
    [Range(0.1f, 3f)]
    public float attackAOE;

    public LayerMask enemyIdentifier;

    public float damage;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");

        attackTime = 0f;
        attackCD = 3f;
    }

    private void Update()
    {
        if (attackTime <= 0) 
        {
            DistanceToPlayer();
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
    }

    private void DistanceToPlayer()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < 2f)
        {
            Debug.Log("Distance Check Met");
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackAOE, enemyIdentifier);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            Debug.Log("Inside AttackPlayer");
            FindObjectOfType<AudioManager>().Play("playerEnemyHit");
            enemiesToDamage[i].GetComponent<PlayerController>().playerHealth -= damage;
            attackTime = attackCD;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(attackPos.position, attackAOE);
    }
}
