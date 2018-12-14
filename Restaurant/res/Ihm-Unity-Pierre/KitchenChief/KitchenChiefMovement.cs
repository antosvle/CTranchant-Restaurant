using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenChiefMovement : MonoBehaviour 
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

            if (walkDirection == 1)
            {
                GoUp();
            }
            else
            {
                GoDown();
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
                moveSpeed = 0f;
                animator.SetBool("IsWalkingDown", false);
                animator.SetBool("IsWalkingUp", false);
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

    void ChooseDirection()
    {
        isWalking = true;
        walkCounter = walkTime;

        if (walkDirection == 1)
        {
            walkDirection = 0;
        }
        else
        {
            walkDirection = 1;
        }
    }

    public void GoUp()
    {
        animator.SetBool("IsWalkingUp", true);
        myRigidBody.velocity = new Vector2(0, moveSpeed);
    }

    public void GoDown()
    {
        animator.SetBool("IsWalkingDown", true);
        myRigidBody.velocity = new Vector2(0, -moveSpeed);
    }
}
