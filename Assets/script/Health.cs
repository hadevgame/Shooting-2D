using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxhealth;
    public int curhealth;

    public HealthBar healthBar;
    void Start()
    {
        curhealth = maxhealth;
        if (healthBar != null)
        {
            healthBar.UpdateBar(curhealth, maxhealth);
        }
    }
   
    void Update()
    {
      
    }

    public void TakeDamage(int damage) 
    {
        curhealth -= damage;

        if (curhealth <= 0) 
        {
            curhealth= 0;
            Destroy(gameObject);
        }

        if (healthBar != null)
        {
            healthBar.UpdateBar(curhealth, maxhealth);
        }
    }
}
