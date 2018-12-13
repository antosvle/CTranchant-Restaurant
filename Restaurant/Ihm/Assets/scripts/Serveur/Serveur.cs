using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serveur : MonoBehaviour, IWorkers, IObserver {

    Vector3 target;
    private bool isBusy = false;
    private float x;
    private float y;
    private Vector3 home = new Vector3(16f, -.5f);


    public void GoTo()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 5 * Time.deltaTime);
    }

    public void LoopMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, home, 5 * Time.deltaTime);
    }

    public void OnNotify(string str)
    {
        getInfo(str);
    }

    public void getInfo(string str){
        x = float.Parse(str.Split(' ')[1]);
        y = float.Parse(str.Split(' ')[2]);
        target = new Vector3(x, y);
    }
    

    void Update () {
        if (!isBusy)
        {
            LoopMovement();
        }
        else
        {
            GoTo();
        }
	}
}
