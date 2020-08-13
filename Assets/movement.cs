using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class movement : MonoBehaviour {
 
    private float speed = 5.0f;
 
    static Animator anim;
 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
 
        anim = GetComponent<Animator>();
    }
 
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
 
        transform.Translate(straffe, 0, translation);
 
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
       
        //Walking
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalk", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRun", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalk", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRun", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalk", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRun", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalk", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRun", false);
        }
        else if (Input.GetKey("left shift"))
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRun", true);
        }
        else
        {
            //Is Idle
            anim.SetBool("isWalk", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("isRun", false);
        }
    }
 
}
 