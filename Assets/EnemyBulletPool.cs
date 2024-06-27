using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    public GameObject bullet;
    public int poolSize;
    private List<GameObject> bulletPool;
    private int bulletsRemaining;
    void Start()
    {
        bulletPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bulletp = Instantiate(bullet);
            bulletp.SetActive(false);
            bulletPool.Add(bulletp);
        }
      
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetBulletFromPool()
    {

        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (!bulletPool[i].activeInHierarchy)
            {
                bulletPool[i].SetActive(true);
                return bulletPool[i];

            }
        }

        return null;
    }

    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);

    }
}
