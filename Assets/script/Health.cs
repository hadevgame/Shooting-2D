using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxhealth;
    public int curhealth;

    public HealthBar healthBar;

    public GameObject heartPrefab;
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

    public void TakeDamageEnemy(int damage)
    {
        curhealth -= damage;
        float random = Random.value;
        if (curhealth <= 0)
        {
            curhealth = 0;
            Destroy(gameObject);
            if (random < 0.5f)
            {
                DropHeart();
            }
            
          
        }

        if (healthBar != null)
        {
            healthBar.UpdateBar(curhealth, maxhealth);

        }
    }

    public void UpdateHealth(int value)
    {
        if (curhealth + value > maxhealth)
        {
            curhealth = maxhealth;
            healthBar.UpdateBar(curhealth, maxhealth);

        }
        else
        {
            curhealth += value;
            healthBar.UpdateBar(curhealth, maxhealth);
        }
    }

    public void DropHeart()
    {
        Vector3 heartPosition = transform.position;
        GameObject heart = Instantiate(heartPrefab, heartPosition, Quaternion.identity);

    }
}
