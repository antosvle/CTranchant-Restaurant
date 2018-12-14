using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateClient : MonoBehaviour {

    public GameObject client = null;
    
	void Start () {
        Instantiate(client, new Vector2(-6.5f, -23.5f), Quaternion.identity);
	}
	
}
