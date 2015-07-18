using UnityEngine;
using System.Collections;

public class SplashHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("nextScene", 5);
	}
	
	void nextScene () { 
		float fadeTime = GameObject.Find ("FadeManager").GetComponent<Fading> ().BeginFade (1);
		Debug.Log (fadeTime);
		yield WaitForSeconds (1);
		Application.LoadLevel (Application.loadedLevel + 1);
	}
}
