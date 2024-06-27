using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timedestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float Time = 2f;
    void Start()
    {
        Destroy(this.gameObject,Time);  // hủy bản sao sau mỗi 2s
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
