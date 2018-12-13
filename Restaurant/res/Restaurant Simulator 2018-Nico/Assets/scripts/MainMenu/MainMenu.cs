using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Library.Utils;

public class MainMenu : MonoBehaviour {

    private void Start()
    {
        GlobalFactory factory = GlobalFactory.GetInstance();

        TransportationService socketManager = factory.GetTransportationService(LocationEnum.IHM);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
