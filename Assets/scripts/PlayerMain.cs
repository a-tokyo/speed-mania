using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour {
	public GameObject player;
	public GameObject road;
	private int score = 0;
	public Text scoreText;
	private float speed = 2.0f;
	//	public Text speedText;
	private float jumpSpeed = 1.2f;
	public bool mute = false;

	private AudioSource audio = null;
	private float laneWidth = 1.8f;
	private int laneCount = 3;
	private float planeWidth = 5.4f;


	public GameObject coinPrefab;
	public GameObject obstaclePrefab;
	public GameObject radarPrefab;


	// Use this for initialization
	void Start () {
		scoreText.text = "" + score;
		audio = GetComponent< AudioSource> ();
		playSound("super-mario");
	}

	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float xTranslation = 0.0f;

		if (transform.position.x + x > -planeWidth && transform.position.x + x < planeWidth) {
			xTranslation = x;
		}

		transform.Translate (new Vector3 (xTranslation,0, speed * Time.deltaTime));
		if (Input.GetKeyDown ("space")){
			playSound("jump");
			transform.Translate(Vector3.up * jumpSpeed);
		}
		if (Input.GetKeyDown ("escape")){
			togglePause ();
		}
		if (Input.GetKeyDown ("c")){
			toggleCamera ();
		}
	}

	void OnCollisionEnter(Collision collisionObject){
		if (collisionObject.gameObject.CompareTag ("Coin")) {
			playSound("coin-collect");
			GameObject.Destroy (collisionObject.gameObject);
			score += 10;
			scoreText.text = "" + score;
		}
		if (collisionObject.gameObject.CompareTag ("Obstacle")) {
			playSound("crash");
			endGame ();
		}
		// adjust speed according to score
		speed = speed * ((int)(speed / 50) + 1);
	}

	void OnTriggerEnter(Collider collisionObject){
		if (collisionObject.CompareTag ("Radar")) {
			playSound("coin-drop");
			//			GameObject.Destroy (collisionObject.gameObject);
			if (score - 50 >= 0) {
				score -= 50;
			} else {
				score = 0;
			}
			scoreText.text = "" + score;
		}
	}


	/**
	 * Plays a sound from the resources folder if the mute is set to false
	 **/
	private void playSound(string musicPath, bool continious = false){
		if (mute) {
			return;
		}
		if (continious) {
			audio.clip = (AudioClip)Resources.Load ("music/" + musicPath);
			audio.Play ();
		} else {
			audio.PlayOneShot((AudioClip)Resources.Load ("music/" + musicPath));
		}
	}


	public void endGame(){
		// @TODO
	}

	public void togglePause(){
		// @TODO
	}

	public void toggleCamera(){
		// @TODO
	}
}