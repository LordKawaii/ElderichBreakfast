using UnityEngine;
using System.Collections;

public class GameJoltCon : MonoBehaviour {
    private GameCon gameCon;
    public bool isOnePlayer;
    public bool isSignedIn = true; 
    void Awake ()
    {
        Object.DontDestroyOnLoad(gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 3)
        {
            gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();

            /*
            GameJolt.UI.Manager.Instance.ShowSignIn((bool success) =>
            {
                if (success)
                {
                    Debug.Log("The user signed in!");
                    gameCon.hasLogedIn = true;
                }
                else
                {
                    GameJolt.UI.Manager.Instance.ShowLeaderboards();
                    Debug.Log("The user failed to signed in or closed the window :(");
                }
            });
             */
        }
    }

	// Use this for initialization
	void Start () 
    {
    }
         
	
	// Update is called once per frame
	void Update () {
	
	}
}
