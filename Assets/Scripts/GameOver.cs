using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    void Start()
    {
        GameJolt.UI.Manager.Instance.ShowLeaderboards();
    }

    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.LoadLevel("MainMenu");

    }
}
