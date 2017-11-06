using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour {
	public GameObject player;
	private int score = 0;
	//	public Text scoreText;
	private float speed = 2.0f;
	//	public Text speedText;
	public bool mute = false;

	private AudioSource audio = null;

	// Use this for initialization
	void Start () {
		audio = GetComponent< AudioSource> ();
		playSound("super-mario");
	}

	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		transform.Translate (new Vector3 (x,0, speed * Time.deltaTime));
		if (Input.GetKeyDown ("space")){
			playSound("super-mario");
			transform.Translate(Vector3.up * 1.2f);
		}
	}

	void OnCollisionEnter(Collision collisionObject){
		if (collisionObject.gameObject.CompareTag ("Coin")) {
			playSound("super-mario");
			GameObject.Destroy (collisionObject.gameObject);
			score += 10;
			//			scoreText.text = "" + score;
		}
		if (collisionObject.gameObject.CompareTag ("Radar")) {
			playSound("super-mario");
			GameObject.Destroy (collisionObject.gameObject);
			if (score - 50 >= 0) {
				score -= 50;
			} else {
				score = 0;
			}
			//			scoreText.text = "" + score;
		}
		if (collisionObject.gameObject.CompareTag ("Obstacle")) {
			playSound("super-mario");
			// @TODO
		}
		speed = speed * ((int)(speed / 50) + 1);
	}


	/**
	 * Plays a sound from the resources folder if the mute is set to false
	 **/
	private void playSound(string resourcesPath, bool continious = false){
		if (mute) {
			return;
		}
		if (continious) {
			
		} else {
			audio.PlayOneShot((AudioClip)Resources.Load (resourcesPath));
		}
	}
}