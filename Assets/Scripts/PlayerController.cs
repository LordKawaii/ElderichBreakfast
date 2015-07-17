using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 10f;
    public float tentionSpeed = 5f;
    public bool isLeftGuy = false;
    public Transform otherGuyTransform;

    private float playerDistance;
    private bool isOnePlayer = true;
    private GameCon gameCon;

	// Use this for initialization
	void Start () {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
	}
	
	// Update is called once per frame
	void Update () {
        playerDistance = Vector2.Distance(otherGuyTransform.position, transform.position);

        InputContoller();
	}


    void InputContoller()
    {
        if (isOnePlayer)
        {
            if (Input.GetAxis("Horizontal") > 0)
                transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            if (Input.GetAxis("Horizontal") < 0)
                transform.Translate(new Vector3(speed * (-1), 0, 0) * Time.deltaTime);
            if (Input.GetAxis("Vertical") > 0)
            { 
                if (isLeftGuy)
                    transform.Translate(new Vector3(tentionSpeed, 0, 0) * Time.deltaTime);
                else
                    transform.Translate(new Vector3(tentionSpeed * (-1), 0, 0) * Time.deltaTime);
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                if (isLeftGuy)
                    transform.Translate(new Vector3(tentionSpeed * (-1), 0, 0) * Time.deltaTime);
                else
                    transform.Translate(new Vector3(tentionSpeed, 0, 0) * Time.deltaTime);
            }
        }
        else
        { }
    }
}
