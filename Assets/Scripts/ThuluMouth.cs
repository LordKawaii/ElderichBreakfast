using UnityEngine;
using System.Collections;

public class ThuluMouth : MonoBehaviour {
    private GameCon gameCon;

    public ParticleSystem bloods;
    private Quaternion rotation;

    void Start()
    {
        gameCon = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameCon>();
        rotation.Set(0, 0, 0, 0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Sacrifice")
        {
            SacrificeCon sacCon = other.GetComponent<SacrificeCon>();
            Instantiate(bloods, other.attachedRigidbody.position, rotation);
            Destroy(other.gameObject);
            if (gameCon.cthuluMood + sacCon.moodValue <= 100)
                gameCon.cthuluMood += sacCon.moodValue * 2;
            else
                gameCon.cthuluMood = 100;
        }
    }

}
