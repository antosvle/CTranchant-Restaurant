using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class clientsScript : MonoBehaviour {
   [SerializeField]
   private float speed;
    [SerializeField]
    private float nbrClients;

    private Vector3 target;
    private float walkTime = 1f;
    private bool isWalking = false;
    private delegate void Direction();
    private Direction dir;

    

    private void Start()
    {
        TextMeshProUGUI  nbr_Client_mesh = GetComponentInChildren<TextMeshProUGUI>();
        nbr_Client_mesh.text = "5";
        ChangeDirection("sit");
        //ChangeDirection("behind");

    }
    private void Update()
    {
        
        if (isWalking)
        {
            walkTime -= Time.deltaTime;
            dir();
            if (walkTime < 0)
            {
                isWalking = false;
            }
        }
    }
    

    private void ChangeDirection(string state)
    {
        isWalking = true;
        if (state == "behind")
        {
            GetComponent<PathFollower>().enabled = true;
            dir = delegate ()
            {
            };
            walkTime = 3;
        }
        if(state == "toward")
        {
            dir = delegate ()
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            };
            walkTime = 1;
        }
        if(state == "sit")
        {
            target = new Vector3(-5f, -2.5f);   //Coordonnées du rang
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
            walkTime = 10;
        }
    }
}