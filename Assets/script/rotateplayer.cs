using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateplayer : MonoBehaviour
{

    public float movespeed = 5f;

    public Rigidbody2D rb;   //vật lý của đối tượng

    public Vector3 moveinput;   //di chuyển

    public Animator animator;  // quản lý chuyển đổi hành động của nhân vật


   
    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();  //lấy ra thành phần Animator của nhân vật
    }

    // Update is called once per frame
    void Update()
    {

        moveinput.x = Input.GetAxis("Horizontal");   //dữ liệu vào trên trục x, -1 đến 1
        moveinput.y = Input.GetAxis("Vertical");     //dữ liệu vào trên trục y
       


        if (moveinput.x != 0)
        {
            if (moveinput.x > 0)
                transform.localScale = new Vector3(1, 1, 0);
            else
                transform.localScale = new Vector3(-1, 1, 0);
        }
    }
}
