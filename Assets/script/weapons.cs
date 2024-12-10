using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class weapons : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public Transform firePos2;
    public Transform firePos3;

    public float Timebtwfire = 0.2f;
    private float timebtwfire;
    public float bulletForce;
    public bulletpool bulletPool;
    public bool fp2;
    public bool fp3;
    void Start()
    {
      
    }

    void Update()
    {
        RoteGun();
        timebtwfire -= Time.deltaTime;

        if(Input.GetMouseButtonDown(0) && timebtwfire <0 && fp2 == false && fp3 == false) 
        {
            firebullet();
        }
        if (Input.GetMouseButtonDown(0) && timebtwfire < 0 && fp2 == true && fp3 == false)
        {
            firebullet2();
        }
        if (Input.GetMouseButtonDown(0) && timebtwfire < 0 && fp2 == true && fp3 == true)
        {
            firebullet3();
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

    void firebullet2()
    {

        timebtwfire = Timebtwfire;
        GameObject bullet1 = bulletPool.GetBulletFromPool();
        GameObject bullet2 = bulletPool.GetBulletFromPool();
        if (bullet1 != null && bullet2 != null)
        {

            bullet1.transform.position = firePos.position;
            bullet2.transform.position = firePos2.position;
            bullet1.transform.rotation = Quaternion.identity;
            bullet2.transform.rotation = Quaternion.identity;
            bullet1.SetActive(true);
            bullet2.SetActive(true);

            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.velocity = transform.right * bulletForce;
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.velocity = transform.right * bulletForce;


            StartCoroutine(ReturnBulletToPoolDelayed(bullet1));
            StartCoroutine(ReturnBulletToPoolDelayed(bullet2));
        }

    }

    void firebullet3()
    {

        timebtwfire = Timebtwfire;
        GameObject bullet1 = bulletPool.GetBulletFromPool();
        GameObject bullet2 = bulletPool.GetBulletFromPool();
        GameObject bullet3 = bulletPool.GetBulletFromPool();
        if (bullet1 != null && bullet2 != null && bullet3 != null)
        {

            bullet1.transform.position = firePos.position;
            bullet2.transform.position = firePos2.position;
            bullet3.transform.position = firePos3.position;

            bullet1.transform.rotation = Quaternion.identity;
            bullet2.transform.rotation = Quaternion.identity;
            bullet3.transform.rotation = Quaternion.identity;

            bullet1.SetActive(true);
            bullet2.SetActive(true);
            bullet3.SetActive(true);

            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.velocity = transform.right * bulletForce;
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.velocity = transform.right * bulletForce;
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.velocity = transform.right * bulletForce;

            StartCoroutine(ReturnBulletToPoolDelayed(bullet1));
            StartCoroutine(ReturnBulletToPoolDelayed(bullet2));
            StartCoroutine(ReturnBulletToPoolDelayed(bullet3));
        }

    }

    private IEnumerator ReturnBulletToPoolDelayed(GameObject bullet)
    {
        yield return new WaitForSeconds(8f);

        bulletPool.ReturnBulletToPool(bullet);
    }
}
