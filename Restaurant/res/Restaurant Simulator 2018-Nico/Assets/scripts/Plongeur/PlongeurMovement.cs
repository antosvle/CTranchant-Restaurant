using UnityEngine;
using System.Collections;

public class PlongeurMovement : MonoBehaviour
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
            moveSpeed = 2.7f;
            walkCounter -= Time.deltaTime;

            if (walkDirection == 1)
            {
                GoRight();
            }
            else
            {
                GoLeft();
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
                moveSpeed = 0f;
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
