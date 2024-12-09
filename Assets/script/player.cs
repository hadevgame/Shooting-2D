using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{

    public float movespeed = 3f;

    public Rigidbody2D rb;   

    public Vector3 moveinput;   

    public Animator animator;  

    public float rollboost = 4f;

    public float RollTime = 0.25f;

    bool checkroll = false;

    private float checkTime ;

    public weapons wp;

    private int countfp =1;
  
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    void Update()
    {
        moveinput.x = Input.GetAxis("Horizontal");   
        moveinput.y = Input.GetAxis("Vertical");     

        transform.position += moveinput * movespeed * Time.deltaTime;

        animator.SetFloat("speed", moveinput.sqrMagnitude);     


        if (Input.GetKeyDown(KeyCode.Space) && checkTime <= 0)
        {
            animator.SetBool("roll", true);
            movespeed += rollboost;
            checkTime = RollTime;
            checkroll = true;
        }

        if (checkTime <= 0 && checkroll==true)
        {
            animator.SetBool("roll", false);
            movespeed -= rollboost;
            checkroll = false;
        }
        else
        {
            checkTime -= Time.deltaTime;
        }
       
           
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(countfp == 1)
        {
            if (collision.CompareTag("fp"))
            {
                wp.fp2 = true;
                Destroy(collision.gameObject);
                countfp += 1;
                return;
            }
        }
        if (countfp == 2) 
        {
            if (collision.CompareTag("fp"))
            {
                wp.fp3 = true;
                Destroy(collision.gameObject);
                countfp += 1;
                return ;
            }
        }
        else if (collision.CompareTag("fp")) Destroy(collision.gameObject);
    }

}
