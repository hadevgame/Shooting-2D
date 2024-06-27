using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy1;

    [SerializeField] 
    private GameObject enemy2;

    [SerializeField]
    private float minSpawTime;

    [SerializeField]
    private float maxSpawTime;

    private float timeUntilSpaw;

   
    void Awake()
    {
        SetTimeUntilSpaw();
    }

    void Update()
    {
        timeUntilSpaw -= Time.deltaTime;
       

        if (timeUntilSpaw <= 0) 
        {
            float randomvalue = Random.Range(0f, 1f);
            if(randomvalue < 0.5f)
            {
                Instantiate(enemy1, transform.position, Quaternion.identity);
            }
            else 
            {
                Instantiate(enemy2, transform.position, Quaternion.identity);
            }
            SetTimeUntilSpaw();
          
        }
    }

    private void SetTimeUntilSpaw()
    {
        timeUntilSpaw = Random.Range(minSpawTime,maxSpawTime);
    }
}
