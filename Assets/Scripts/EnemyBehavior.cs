using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float hitPoints;
    public float maxHitPoints = 1f;
    public HealthbarBehavior Healthbar;

    void Start()
    {
        hitPoints = maxHitPoints;
        Healthbar.SetHealth(hitPoints, maxHitPoints);
    }

    void Update()
    {
        Healthbar.SetHealth(hitPoints, maxHitPoints);
        
        if(hitPoints < 0)
        {
            Destroy(gameObject);
            hitPoints = 1;
        }
    }

    private void FindTarget()
    {
        float detectionRange = 20f;
        if(Vector3.Distance(transform.position, PlayerController.playerInstance.transform.position) < detectionRange )
        {
            //set target vector to player pos???
        }
    }
}
