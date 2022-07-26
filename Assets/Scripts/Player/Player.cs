using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;

    public CharacterController characterController;
    public float speed =1f;
    public float turnSpeed = 1f;
    public bool canMove = false;

    [Header("Gravity")]
    public float gravity = 9.8f;
    public float vSpeed = 0f;
    public float jumpSpeed = 15f;

    [Header("Gravity")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;
    void Update()
    {
        if(canMove)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        }

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (characterController.isGrounded)
        {
            vSpeed = 0;
            if (Input.GetKey(KeyCode.Space) && canMove)
            {
                vSpeed = jumpSpeed;
                StartCoroutine(VFX_JUMP());
                
            }    

        }

        IEnumerator VFX_JUMP()
        {
            animator.SetBool("Jump", true);
            yield return new WaitForSeconds(.5f);
            animator.SetBool("Jump", false);
        }

        vSpeed -= gravity * Time.deltaTime;
        if (canMove)
        {
            speedVector.y = vSpeed;
            characterController.Move(speedVector * Time.deltaTime);

        }


        var isWalking = inputAxisVertical != 0;

        if (isWalking  && canMove)
        {
            if (Input.GetKey(keyRun) && canMove)
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;
            }
        }

        animator.SetBool("Run", isWalking&&canMove);
        

    }

    

}
