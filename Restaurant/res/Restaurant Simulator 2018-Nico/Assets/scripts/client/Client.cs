using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class Client : MonoBehaviour {
   [SerializeField]
   private float speed;
    [SerializeField]
    private float nbrClients;

    private Vector3 target;
    private delegate void Direction();
    private Direction dir;
    private bool isWalking = true;
    private string state;
    public bool tableAvailable;




    private void Start()
    {
        TextMeshProUGUI  nbr_Client_mesh = GetComponentInChildren<TextMeshProUGUI>();
        nbr_Client_mesh.text = "5";
        ChangeDirection("toward");

    }
    private void Update()
    {
        if (isWalking)
        {
            dir();
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            tableAvailable = true;
        }
    }
    

    private void ChangeDirection(string state)
    {
        this.state = state;
        if (state == "toward")
        {
            target = new Vector3(-6.5f,-23f);
            dir = delegate ()
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

                if (transform.position == target)
                {
                    state = "behind";
                    ChangeDirection(state);
                }
            };
        }
        if (state == "behind")
        {
            GetComponent<PathFollower>().enabled = true;
            dir = delegate ()
            {
                if (tableAvailable)
                {
                    state = "sit";
                    ChangeDirection(state);
                }
            };
        }
        if(state == "sit")
        {
            target = new Vector3(-5f, -2.5f);   //Coordonnées du rang
            GetComponent<PathFollower>().enabled = false;
            dir = delegate ()
            {
                if (transform.position != target)
                {
                    Debug.Log("sit");
                    transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);
                }
                else
                {
                    target = new Vector3(-19.5f, 1f); //Coordonnées de la table
                }
            };
        }
    }
}