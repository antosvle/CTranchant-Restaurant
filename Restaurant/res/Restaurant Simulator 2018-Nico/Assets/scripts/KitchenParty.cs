using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class KitchenParty: MonoBehaviour {

    public float speed;
    private Vector3 target;
    private bool isWalking = false;
    private delegate void Direction();
    private Direction dir;
    public Animator animator;

    private void Start()
    {
       ChangeDirection("LeftToRight");
    }

    private void Update()
    {
        if (isWalking)
        {
            dir();
            Debug.Log("dab");
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
                    GoTo();
                }
                else 
                {
                    isWalking = false;
                    Debug.Log("bigoune");
                    animator.SetFloat("Speed", 0f);
                    animator.SetBool("IsWalkingRight", false);
                    //GoTo(23f, -3f);
                }
            };
        }
        if(state == "toward")
        {
            dir = delegate ()
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            };
        }
        if(state == "sit")
        {

            dir = delegate ()
            {
                if (transform.position != target)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
                }
                else
                {
                    target = new Vector3(-19.5f, 1.5f); //Coordonées de la table
                }
            };
        }
    }

    public void GoTo() 
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}