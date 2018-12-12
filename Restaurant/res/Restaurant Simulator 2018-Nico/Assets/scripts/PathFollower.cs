using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {

    Node[] pathNode;
    public GameObject player;

    public float moveSpeed;

    Vector3 currentPositionHolder;
    int currentNode;
    float timer =0;

    void Start ()
    {
        player = gameObject;
        moveSpeed = .2f; 
        pathNode = GameObject.FindGameObjectWithTag("path_behind").GetComponentsInChildren<Node>();
        CheckNode();
    }
	
    void CheckNode()
    {
        if(currentNode<pathNode.Length-1)
        timer = 0;
        currentPositionHolder = pathNode[currentNode].transform.position;
    }


	void Update () {
        timer += Time.deltaTime * moveSpeed;
        if(player.transform.position != currentPositionHolder)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, currentPositionHolder, timer);
        }
        else
        {
            if (currentNode < pathNode.Length-1)
            {
                currentNode++;
                CheckNode();
            }

        }
	}
}
