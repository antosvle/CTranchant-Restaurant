using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenChief : Subject
{

    #region Singleton
    private static KitchenChief _instance;
    public static KitchenChief Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("KitchenChief");
                go.AddComponent<KitchenChief>();
            }

            return _instance;
        }
    }
    #endregion

    public delegate void ExecuteOrder(bool execute);
    public static event ExecuteOrder Exe;

    private bool NewOrder;

    private void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            NewOrder = true;
            Notify();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            NewOrder = false;
        }

        if (NewOrder)
        {
            if (Exe != null)
            {
                Exe(true);
            }
        }
    }
}
