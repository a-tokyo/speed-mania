using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	//	pause : Time.timeScale = 0.0f; 1.0f;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
		Time.timeScale = 1.0f;
	}

	// Update is called once per frame
	void Update () {

	}

	public void Quit(){
		Application.Quit ();
	}

	public void Toggle(){
		if (Time.timeScale == 0.0f) {
			gameObject.SetActive (false);
			Time.timeScale = 1.0f;
		} else {
			gameObject.SetActive (true);
			Time.timeScale = 0.0f;
		}
	}
}
