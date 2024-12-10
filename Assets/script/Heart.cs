using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    
    public int value;
    Health health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            health = collision.GetComponent<Health>();
            health.UpdateHealth(value);
            Destroy(gameObject);
        }
    }


}