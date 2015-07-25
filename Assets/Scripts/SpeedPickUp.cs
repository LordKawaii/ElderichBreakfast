using UnityEngine;
using System.Collections;

public class SpeedPickUp : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
            {
                player.GetComponent<PlayerController>().GottaGoFast();
            }
        }
    }

}
