using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefCuisinierMovement : MonoBehaviour
{

    public float moveSpeed;

    private Rigidbody2D myRigidBody;
    public Animator animator;

    public bool isWalking;

    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;

    private int walkDirection;

    // Use this for initialization
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));

        if (isWalking)
        {
            moveSpeed = 2f; 
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    animator.SetBool("IsWalkingUp", true);
                    myRigidBody.velocity = new Vector2(0, moveSpeed);
                    break;

                case 1:
                    animator.SetBool("IsWalkingRight", true);
                    myRigidBody.velocity = new Vector2(moveSpeed, 0);
                    break;

                case 2:
                    animator.SetBool("IsWalkingDown", true);
                    myRigidBody.velocity = new Vector2(0, -moveSpeed);
                    break;

                case 3:
                    animator.SetBool("IsWalkingLeft", true);
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
                moveSpeed = 0f;
                animator.SetBool("IsWalkingRight", false);
                animator.SetBool("IsWalkingUp", false);
                animator.SetBool("IsWalkingDown", false);
                animator.SetBool("IsWalkingLeft", false);
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            myRigidBody.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection() 
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
