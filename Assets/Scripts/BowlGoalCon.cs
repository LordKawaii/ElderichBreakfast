using UnityEngine;
using System.Collections;

public class BowlGoalCon : MonoBehaviour {
    GameCon gameCon;
    SacrificeCon sacCon;
    const int maxScore = 100;

    public ParticleSystem milk;
    private Quaternion rotation;
    private Vector3 position;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Sacrifice")
        {
            sacCon = other.GetComponent<SacrificeCon>();
            int score =  Mathf.FloorToInt(other.GetComponent<SacrificeCon>().scoreValue/Vector2.Distance(transform.position, other.transform.position) * gameCon.scoreMultiplyer);
            gameCon.score += Mathf.FloorToInt(score * gameCon.scoreMultiplyer);
            gameCon.scoreMultiplyer += gameCon.multiplyerIncrement;
            Debug.Log("Score: " + score.ToString());
           
            if (gameCon.cthuluMood + sacCon.moodValue <= 1)
                gameCon.cthuluMood += sacCon.moodValue;
            else
                gameCon.cthuluMood = 1;
            position = other.attachedRigidbody.position;
            position.z = -150;
            Instantiate(milk, position, rotation);
            Destroy(other.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}