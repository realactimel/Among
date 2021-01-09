using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public Animator animator;
    bool facingRight = true;
    void HandleMovement()
    {  
        if (isLocalPlayer){
            float moveHorizontal = Input.GetAxis("Horizontal");

            if(moveHorizontal<0 && facingRight)
            {
                flip();
            }
            if(moveHorizontal>0 && !facingRight)
            {
                flip();
            }

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));

            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal * 0.1f, moveVertical * 0.1f, 0);
            transform.position = transform.position + movement;
            animator.SetFloat("Speed", Mathf.Abs(moveVertical));
        
        }
        
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f,0f);
    }
    
    void Update()
    {
        HandleMovement();
    }
}
