using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.UI;

public class GameCon : MonoBehaviour {

    const int MULTI_START_VAL = 1;
    const int TABLEID = 0;
    const string EXTRA_DATA = "";

    public float maxPlayerDistance = 16f;
    public float minPlayerDistance = 5f;
    public Transform player1;
    public Transform player2;
    public bool ctrl1Found = false;
    public bool ctrl2Found = false;
    public InputDevice controllerP1;
    public InputDevice controllerP2;
    public int score = 0;
    public float multiplyerIncrement = .1f;
    public float scoreMultiplyer = MULTI_START_VAL;
    public float buildingDistructionRate = .01f;
    public float buildingHeath;
    public float cthuluMood = 1;
    public float angerRate = .01f;
    
    public Text scoreText;
    public Text multiplyerText;
    public Image buildingBar;
    public Image MoodBar;
    
    public bool isOnePlayer = false;
    
    private bool hasLogedIn = false;
    private bool hasSentScore = false;
    private bool gameOver = false;

    private GameJoltCon gjCon;

    public bool HasLoggedIn()
    {
        return hasLogedIn;
    }

    void Awake()
    {
        if (InputManager.Devices.Count >= 1 && InputManager.Devices[0] != null)
        {
            controllerP1 = InputManager.Devices[0];
            ctrl1Found = true;
        }

        if (InputManager.Devices.Count >= 2 && InputManager.Devices[1] != null)
        { 
            controllerP2 = InputManager.Devices[1];
            ctrl2Found = true;
        }
        
    }

	// Use this for initialization
	void Start () {
        gjCon = GameObject.Find("GameJoltAPI").GetComponent<GameJoltCon>();
        isOnePlayer = gjCon.isSignedIn;
        hasLogedIn = gjCon.isSignedIn;
		score = 0;
        buildingHeath = buildingBar.fillAmount;
	}
	
	// Update is called once per frame
	void Update () {



        if (hasLogedIn)
        {

            if (cthuluMood >= 0)
                cthuluMood -= angerRate * Time.deltaTime;

            if (cthuluMood <= .75f)
            {
                buildingHeath -= ((1 - cthuluMood)) * buildingDistructionRate * Time.deltaTime;
            }

            scoreText.text = "Score: " + score.ToString();
            multiplyerText.text = "X" + scoreMultiplyer.ToString();
            buildingBar.fillAmount = buildingHeath;
            MoodBar.fillAmount = cthuluMood;

            if (buildingHeath <= 0)
            {
                gameOver = true;
                LogOut();
            }
        }
        
	}

    public float PlayerDistance()
    {

        return Vector2.Distance(player1.position, player2.position);
    }

    public void ResetMulti()
    {
        scoreMultiplyer = MULTI_START_VAL;
    }

    void LogOut()
    {
        if (!hasSentScore)
        {
            GameJolt.API.Scores.Add(score, scoreText.text + score, TABLEID, EXTRA_DATA);
            hasSentScore = true;
            Application.LoadLevel("GameOver");
        }
        
    }

    
}
