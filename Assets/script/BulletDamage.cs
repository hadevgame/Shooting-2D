using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    
    enemy enim;
    public int damage = 3;
    public bool bullet;
    bulletpool blp;
    //h

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !bullet)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Enemy") && bullet)
        {
            collision.GetComponent<Health>().TakeDamageEnemy(damage);
            gameObject.SetActive(false);
            blp.ReturnBulletToPool(gameObject);
        }


    }
    
    
   
  
}
