using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyChiefMovement : Observer
{

    public float moveSpeed;

    private Rigidbody2D myRigidBody;
    public Animator animator;

    public Transform oven;
    public Transform sink;

    public bool isWalking;
    private bool isOccupied;
    public bool isFree;

    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;

    private int walkDirection;

    // Use this for initialization
    void Start()
    {

        foreach (var KitchenChief in FindObjectsOfType<KitchenChief>())
        {
            KitchenChief.AddObserver(this);
        }

        myRigidBody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        isOccupied = false;

        ChooseDirection();
    }

    public void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveSpeed));

        if (isWalking)
        {
            moveSpeed = 2f;
            walkCounter -= Time.deltaTime;

            if (isOccupied)
            {
                switch (walkDirection)
                {
                    case 1:
                        GoToOven();
                        break;

                    case 2:
                        GoToSink();
                        break;

                    case 3:
                        GoDown();
                        break;

                    case 4:
                        GoLeft();
                        break;
                }
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
                moveSpeed = 0f;
                animator.SetBool("IsWalkingDown", false);
                animator.SetBool("IsWalkingUp", false);
                animator.SetBool("IsWalkingLeft", false);
                animator.SetBool("IsWalkingRight", false);
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
        Walk();

        walkDirection++;

        if (walkDirection == 5)
        {
            walkDirection = 1;
        }
    }

    public void GoToOven()
    {
        // The step size is equal to speed times frame time.
        float step = moveSpeed * Time.deltaTime;

        animator.SetBool("IsWalkingUp", true);

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, oven.position, step);
    }

    public void GoToSink()
    {
        // The step size is equal to speed times frame time.
        float step = moveSpeed * Time.deltaTime;

        animator.SetBool("IsWalkingUp", true);

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, sink.position, step);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");

        if (collision.gameObject.name == "Oven")
        {
            myRigidBody.velocity = Vector3.zero;
            walkCounter = 0;
        }

        if (collision.gameObject.name == "Sink")
        {
            myRigidBody.velocity = Vector3.zero;
            walkCounter = 0;
        }
    }

    void Walk ()
    {
        isWalking = true;
        walkCounter = walkTime;
    }

    public override void OnNotify()
    {
        Debug.Log("New order");

        if (isFree)
        {
            isOccupied = true;
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

    public void GoLeft()
    {
        animator.SetBool("IsWalkingLeft", true);
        myRigidBody.velocity = new Vector2(-moveSpeed, 0);
    }

    public void GoRight()
    {
        animator.SetBool("IsWalkingRight", true);
        myRigidBody.velocity = new Vector2(moveSpeed, 0);
    }
}
