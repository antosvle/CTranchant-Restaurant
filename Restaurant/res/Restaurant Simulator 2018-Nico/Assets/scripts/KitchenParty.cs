using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class KitchenParty: MonoBehaviour, IObserver {

    public float speed;
    private Vector3 target;
    private bool isWalking;
    private delegate void Direction();
    private Direction dir;
    public Animator animator;
    public float waitTimer;
    private float wait;
    private string order;

    private void Start()
    {
        ChangeDirection("counter");
        wait = waitTimer;
    }

    private void Update()
    {
        if (this.order != null)
        {
            ChangeDirection(order);
        }

        if (isWalking)
        {
            dir();
        }
        else
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer < 0)
            {
                waitTimer = wait;

                WaitingOrder();
            }
        }
    }

    private void ChangeDirection(string state)
    {
        isWalking = true;
        animator.SetFloat("Speed", Mathf.Abs(speed));

        if (state == "LeftToRight")
        {
            target = new Vector3(25.7f, -3f);
            dir = delegate ()
            {
                if (transform.position != target)
                {
                    animator.SetBool("IsWalkingRight", true);
                    animator.SetFloat("Speed", speed);
                    GoTo();
                }
                else if (transform.position == target)
                {
                    isWalking = false;
                    animator.SetFloat("Speed", 0f);
                    animator.SetBool("IsWalkingRight", false);
                }
            };
        }

        if (state == "RightToLeft")
        {
            target = new Vector3(23f, -3f);
            dir = delegate ()
            {
                if (transform.position != target)
                {
                    animator.SetBool("IsWalkingLeft", true);
                    animator.SetFloat("Speed", speed);
                    GoTo();
                }
                else if (transform.position == target)
                {
                    isWalking = false;
                    animator.SetFloat("Speed", 0f);
                    animator.SetBool("IsWalkingLeft", false);
                }
            };
        }

        if (state == "counter")
        {
            target = new Vector3(19.5f, -5f);
            dir = delegate ()
            {
                if (transform.position != target)
                {
                    animator.SetBool("IsWalkingLeft", true);
                    animator.SetFloat("Speed", speed);
                    GoTo();
                }
                else if (transform.position == target)
                {
                    isWalking = false;
                    animator.SetFloat("Speed", 0f);
                    animator.SetBool("IsWalkingLeft", false);
                }
            };
        }
    }

    public void GoTo() 
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void WaitingOrder()
    {
        if (transform.position == new Vector3(23f, -3f))
        {
            ChangeDirection("LeftToRight");
        }

        if (transform.position == new Vector3(25.7f, -3f))
        {
            ChangeDirection("RightToLeft");
        }

        if (transform.position == new Vector3(19.5f, -5f))
        {
            ChangeDirection("LeftToRight");
        }
    }

    public void OnNotify(string str)
    {
        if (str.Split(' ')[0] == "partyChief")
        {
            this.order = str.Split(' ')[1];
        }
    }
}