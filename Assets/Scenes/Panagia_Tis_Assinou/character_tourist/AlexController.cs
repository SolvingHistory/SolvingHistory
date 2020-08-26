using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexController : MonoBehaviour
{
    public Transform mainCamera;
    private Animator animComp;
    private int movementState;
    private int prevMovementState;
    private bool isRunning;
    
    private enum CharacterMovement{IDLE=0,WALK=1,RUN=2,JUMP=3};
    // Start is called before the first frame update
    void Start()
    {
        animComp = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyUp(KeyCode.Space))
       {
          prevMovementState = movementState;
          movementState = (int)CharacterMovement.JUMP; 
       }
       else if (movementState == (int)CharacterMovement.JUMP)
       {
            if (getCharacterAnimatorState() != (int)CharacterMovement.JUMP)
            {
               movementState = prevMovementState; 
            }
       } 
       else if(Input.GetKeyDown(KeyCode.W))
       {
           movementState = (int) CharacterMovement.WALK;
       }
       else if(Input.GetKeyDown(KeyCode.LeftShift))
       {
           isRunning = true;
       }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
       {
           isRunning = false;
       }
        if(Input.GetKeyUp(KeyCode.W))
       {
           movementState = (int) CharacterMovement.IDLE;
       }
       

       if(isRunning == true && movementState == (int) CharacterMovement.WALK)
       {
           movementState = (int)CharacterMovement.RUN; 
       }
       else if(isRunning == false && movementState == (int) CharacterMovement.RUN)
       {
           movementState = (int)CharacterMovement.WALK;
       }
       animComp.SetInteger("AlexState",movementState);
       this.transform.rotation=mainCamera.rotation;
    }
    int getCharacterAnimatorState()
    {
        int jumpState = Animator.StringToHash("Base.Alex_jumping");
        int walkState = Animator.StringToHash("Base.Alex_walking");
        int idleState = Animator.StringToHash("Base.Alex_idle");
        int runState = Animator.StringToHash("Base.Alex_running");

        AnimatorStateInfo currentBaseState = animComp.GetCurrentAnimatorStateInfo(0);

        if(currentBaseState.fullPathHash == jumpState)
        {
            return (int)CharacterMovement.JUMP;
        }
        else if(currentBaseState.fullPathHash == walkState)
        {
            return (int)CharacterMovement.WALK;
        }
        else if(currentBaseState.fullPathHash == runState)
        {
            return (int)CharacterMovement.RUN;
        }
        else 
        {
            return (int)CharacterMovement.IDLE;
        }


    }

}
