using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Library.Utils;

public class MainMenu : MonoBehaviour {

    private void Start()
    {
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
