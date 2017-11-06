using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {
	public Text scoreText;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToggleEndMenu(int score = 0){
		gameObject.SetActive (true);
		scoreText.text = "" + score;
	}
}
