using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] int maxhealth;
    public int curhealth;

    public HealthBar healthBar;

    public GameObject heartPrefab;
    public GameOverMenu goMenuUI;
    Animator animator;
    private bool isDead = false;
    void Start()
    {
        animator = GetComponent<Animator>();

        curhealth = maxhealth;
    }
   
    void Update()
    {
      
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        curhealth -= damage;

        if (curhealth <= 0 && !isDead)
        {
            curhealth = 0;
            isDead = true;
            //animator.SetTrigger("dead");
            goMenuUI.DisplayGameOver();
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
