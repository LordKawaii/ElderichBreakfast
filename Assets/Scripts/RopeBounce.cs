using UnityEngine;
using System.Collections;

public class RopeBounce : MonoBehaviour {
    public float bounceForce = 500f;
    
    private GameCon gameCon;

	// Use this for initialization
	void Start () {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
	}
	
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "RopeSegment")
        {
            Rigidbody2D otherBody = other.transform.GetComponent<Rigidbody2D>();
            if (otherBody != null)
            { 
                otherBody.AddForce(Vector2.up * bounceForce * (gameCon.PlayerDistance() - gameCon.minPlayerDistance));
                
                Debug.Log("Bounce");
            }
        }


    }
}
