using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour {
	public GameObject player;
	private int score = 0;
	//	public Text scoreText;
	private float speed = 1.0f;
	//	public Text speedText;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		transform.Translate (new Vector3 (x,0, speed * Time.deltaTime));
		if (Input.GetKeyDown ("space")){
			transform.Translate(Vector3.up * 1.2f);
		}
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
		if (c.gameObject.CompareTag ("Obstacle")) {
			// @TODO
		}
		speed = speed * ((int)(speed / 50) + 1);
	}
}