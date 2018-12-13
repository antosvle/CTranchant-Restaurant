using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefDeRang : MonoBehaviour, IWorkers, Observer
{


    public Transform[] target;
    public float speed;
    public bool looping = true;

    private int current =0;

    private bool ascendant = true;

    public Vector3 targetToGo;
    private float x;
    private float y;



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

    public void getInfo(string str)
    {
        x = float.Parse(str.Split(' ')[1]);
        y = float.Parse(str.Split(' ')[2]);
        targetToGo = new Vector3(x, y);
    }

    public void OnNotify(string str)
    {
        getInfo(str);
    }
}
