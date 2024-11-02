using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Pathfinding;

public class enemy : MonoBehaviour
{
    
    public bool roaming = true;  
    public Seeker seeker;
    public float moveSpeed = 3f;
    public float nextWPDistance = 3f;
    public bool shootable = false;
    public GameObject bullet;
    public float bulletspeed;
    public float timebtwFire;
    public int damage = 4;

    bool reachDes = false;
    private float fireCD;
   

    Path path;
    Coroutine moveCoroutine;
    Health health;
    Health eHealth;

     void Start()
     {
         eHealth = GetComponent<Health>();
         InvokeRepeating("CaculatePath", 0f, 0.5f);  
         reachDes = true;
     }

    void Update()
    {
        fireCD -= Time.deltaTime;
        if (fireCD < 0)
        {
            fireCD = timebtwFire;
            EnemyFireBullet();
        }

    }

     void CaculatePath()
     {
        Vector2 target = FindTarget();
        if (seeker.IsDone())
            seeker.StartPath(transform.position, target, OnPathComplete);
     }
     void OnPathComplete(Path p) 
     {
         if (p.error) return;
            path= p;
         MoveToTarget();
        
    }

    Vector2 FindTarget()
    {
        Vector3 playerPos = FindObjectOfType<player>().transform.position;
        Vector3 rotate = playerPos - transform.position;
        if (rotate.x < 0 && rotate.y > 0 || rotate.x < 0 && rotate.y < 0)
            transform.localScale = new Vector3(-1, 1, 0);
        else
            transform.localScale = new Vector3(1, 1, 0);

        if (roaming == true)
        {
            return (Vector2)playerPos + (Random.Range(3f, 6f) * new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized);// khoảng cách ngẫu nhiên xung quanh player
        }
        else
        {
            return playerPos;
        }
    }

    void MoveToTarget()    
     {
         if (moveCoroutine != null) StopCoroutine(moveCoroutine);   
         moveCoroutine = StartCoroutine(MoveToTargetCoroutine());    
     }

     IEnumerator MoveToTargetCoroutine() 
     {
         int currentWP = 0;
         reachDes= false;
         while(currentWP < path.vectorPath.Count) 
         {
             Vector2 directtion = ((Vector2)path.vectorPath[currentWP]-(Vector2)transform.position).normalized; //tính hướng di chuyển từ vị trí hiện tại tới điểm trên đường đi
             Vector2 force = directtion * moveSpeed * Time.deltaTime;
             transform.position += (Vector3)force;

             float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
             if (distance < nextWPDistance)
                 currentWP++;
             yield return null;
         }
         reachDes = true;
     }
    

     void EnemyFireBullet() 
     {
          var bullettmp = Instantiate(bullet, transform.position, Quaternion.identity);
          Rigidbody2D rb = bullettmp.GetComponent<Rigidbody2D>();
          Vector3 playerPos = FindObjectOfType<player>().transform.position;
          Vector3 direction = playerPos - transform.position;
          rb.AddForce(direction.normalized * bulletspeed,ForceMode2D.Impulse);

     }


     private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Player"))
         {
             health = collision.GetComponent<Health>();
             
             InvokeRepeating("DamagePlayer", 0f, 0.2f);
         }
     }

     private void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.CompareTag("Player"))
         {
             health = null;
             CancelInvoke("DamagePlayer");
         }
     }

     void DamagePlayer()
     {
         if(health != null)
             health.TakeDamage(damage);
     }

}
