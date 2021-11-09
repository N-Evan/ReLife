using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private float attackCooldown;
    public float timeBetweenAttack;

    public Transform attackPos;
    public float attackAOE;

    public LayerMask enemyIdentifier;

    public float damage;
    void Update()
    {
        if(attackCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
            }
            attackCooldown = timeBetweenAttack;
        } 
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
    }

    void Attack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackAOE, enemyIdentifier);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            FindObjectOfType<AudioManager>().Play("enemyDamaged");
            /*Debug.Log(enemiesToDamage[i].GetComponent<EnemyBehavior>().hitPoints);*/
            enemiesToDamage[i].GetComponent<EnemyBehavior>().hitPoints -= damage;
            /*Debug.Log(enemiesToDamage[i].GetComponent<EnemyBehavior>().hitPoints);*/
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackAOE);
    }
}