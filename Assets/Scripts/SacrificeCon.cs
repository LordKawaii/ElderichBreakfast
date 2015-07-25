using UnityEngine;
using System.Collections;

public class SacrificeCon : MonoBehaviour {

    public int scoreValue = 100;
    public float moodValue = .1f;
  

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(-3, 3) * 1000);
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * Random.Range(-.5f, .5f) * 400);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
