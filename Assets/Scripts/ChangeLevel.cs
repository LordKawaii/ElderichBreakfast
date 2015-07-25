using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour
{
     private GameJoltCon gameJCon;

	// Use this for initialization
	void Start () {
        gameJCon = GameObject.FindGameObjectWithTag("API").GetComponent<GameJoltCon>();
        if (gameJCon == null)
            Debug.Log("gameJCon not found");
        gameJCon.isSignedIn = GameJolt.API.Manager.Instance.CurrentUser != null;
        gameJCon.isOnePlayer = true;
    }

	public void menuScreen () {
		selectScreen ("MainMenu");
	}

	public void playScreenP1 () {
        //gameJCon.isOnePlayer = true;
		selectScreen ("GameScreen");
	}

    public void playScreenP2()
    {
        gameJCon.isOnePlayer = false;
        selectScreen("GameScreen");
    }


	public void scoreScreen () {
        GameJolt.UI.Manager.Instance.ShowLeaderboards();
	}

	void selectScreen (string levelID) {
		Application.LoadLevel (levelID);
	}

	public void exitKey () {
		Application.Quit();
	}

	void Update() {
		if (Input.GetKey("escape"))
			Application.Quit();
		
	}
}