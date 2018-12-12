using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefDeRang : MonoBehaviour, IWorkers
{


    public Transform[] target;
    public float speed;
    public bool looping = true;

    private int current =0;

    private bool ascendant = true;

    public Vector3 targetToGo;



    public void GoTo()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetToGo, 5 * Time.deltaTime);
        if(transform.position == targetToGo)
        {
            looping = false;
        }
    }

    public void LoopMovement()
    {
        if (transform.position != target[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
        }
        else
        {
            if (current < target.Length - 1 && ascendant)
            {
                current++;
            }
            else
            {
                current--;
                ascendant = false;
                if (current == 0)
                {
                    ascendant = true;
                }
            }
        }
    }
 

    void Start () {
		
	}
	
	void Update () {
        if (looping)
        {
            LoopMovement();
        }
        else
        {
            GoTo();
        }
	}
}
