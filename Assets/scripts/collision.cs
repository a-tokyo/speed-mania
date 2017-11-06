using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collision : MonoBehaviour {

	//	public Text scoreText;
	public int score = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision c){
//		GetComponent< AudioSource> ().Play ();
		if (c.gameObject.CompareTag ("Coin")) {
			GameObject.Destroy (c.gameObject);
			score += 10;
			//			scoreText.text = "" + score;
		}
		if (c.gameObject.CompareTag ("Radar")) {
			GameObject.Destroy (c.gameObject);
			if (score - 50 >= 0) {
				score -= 50;
			} else {
				score = 0;
			}
			//			scoreText.text = "" + score;
		}
	}
}
