using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class weapons : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float Timebtwfire = 0.2f;
    private float timebtwfire;
    public float bulletForce;
    public bulletpool bulletPool;
    void Start()
    {
      
    }

    void Update()
    {
        RoteGun();
        timebtwfire -= Time.deltaTime;

        if(Input.GetMouseButtonDown(0) && timebtwfire <0) 
        {
            firebullet();
        }
    }

    void RoteGun() 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  
        
        Vector2 lookDir = mousePos - transform.position;                         
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;        
                                                                                

        Quaternion rotation = Quaternion.Euler(0, 0, angle);                    
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(1, -1, 0);
        else
            transform.localScale = new Vector3(1, 1, 0);
    }

    void firebullet()
    {
       
            timebtwfire = Timebtwfire;
            GameObject bullett = bulletPool.GetBulletFromPool();

            if (bullett != null)
            {

                bullett.transform.position = firePos.position;
                bullett.transform.rotation = Quaternion.identity;
                bullett.SetActive(true);

                Rigidbody2D rb = bullett.GetComponent<Rigidbody2D>();
                rb.velocity = transform.right * bulletForce;


                StartCoroutine(ReturnBulletToPoolDelayed(bullett));
            }
        
    }

    private IEnumerator ReturnBulletToPoolDelayed(GameObject bullet)
    {
        yield return new WaitForSeconds(10f);

        bulletPool.ReturnBulletToPool(bullet);
    }
}
