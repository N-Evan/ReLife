using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHazard : MonoBehaviour
{
    public float trapDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trap collision & damage");
            FindObjectOfType<AudioManager>().Play("playerHit");
            collision.gameObject.GetComponent<PlayerController>().DamageCounter(trapDamage);
        }
    }
}
