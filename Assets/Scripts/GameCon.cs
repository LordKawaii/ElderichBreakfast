using UnityEngine;
using System.Collections;

public class GameCon : MonoBehaviour {
    public float maxPlayerDistance = 16f;
    public float minPlayerDistance = 5f;
    public Transform player1;
    public Transform player2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float PlayerDistance()
    {

        return Vector2.Distance(player1.position, player2.position);
    }
}
