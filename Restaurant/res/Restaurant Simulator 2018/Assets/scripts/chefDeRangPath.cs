using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chefDeRangPath : MonoBehaviour {


    public Transform[] target;
    public float speed;

    private int current =0;

    private bool ascendant = true;

    void Start () {
		
	}
	
	void Update () {
		if(transform.position != target[current].position)
        {
           transform.position = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            //GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            if (current <target.Length-1 && ascendant)
            {
                current++;
            }else
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
}
