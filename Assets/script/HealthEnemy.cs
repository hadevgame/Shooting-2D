using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] int maxhealth;
    public int curhealth;
    public GameObject heartPrefab;
    public GameObject fpbPrefab;
    void Start()
    {
        curhealth = maxhealth;
        
    }
    public void TakeDamageEnemy(int damage)
    {
        curhealth -= damage;
        float random = Random.value;
        if (curhealth <= 0)
        {
            curhealth = 0;
            Destroy(gameObject);
            if (random < 0.1f)
            {
                DropFirePosBoost();
            }
            if (random >= 0.1f && random < 0.4f)
            {
                DropHeart();
            }

        }
        
    }

    public void DropHeart()
    {
        Vector3 heartPosition = transform.position;
        GameObject heart = Instantiate(heartPrefab, heartPosition, Quaternion.identity);

    }

    public void DropFirePosBoost()
    {
        Vector3 fpbPos = transform.position;
        GameObject fpb = Instantiate(fpbPrefab, fpbPos, Quaternion.identity);
    }


}
