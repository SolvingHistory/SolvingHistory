using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    static Animator anim;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        
        transform.Translate(0,0,translation);
        transform.Rotate(0,rotation,0);
        
        if(Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isJumping");
        }
         //Walking
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey("left shift"))
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", true);
        }
        else
        {
            //Is Idle
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
        }
    //     if(translation!=0)
    //     {
    //         anim.SetBool("isWalking",true);
    //         anim.SetBool("isIdle",true);
    //     }
    //     else
    //     {
    //         anim.SetBool("isWalking",false);
    //         anim.SetBool("isIdle",true);
    //     }
    //      if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)) 
    //      {
    //          anim.SetBool("isRunning",true);
    //      }
 
        
    }
}
