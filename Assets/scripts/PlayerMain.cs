using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMain : MonoBehaviour {
	public GameObject player;
	public GameObject road;
	private int score = 0;
	public Text scoreText;
	private float speed = 6.0f;
	//	public Text speedText;
	private float jumpSpeed = 2.0f;
	public bool mute = false;

	private AudioSource audio = null;
	private float laneWidth = 1.8f;
	private int laneCount = 3;
	private float planeWidth = 5.4f;


	public GameObject coinPrefab;
	public GameObject obstaclePrefab;
	public GameObject radarPrefab;



	public DeathMenu deathMenu;
	public PauseMenu pauseMenu;


	public Camera mainCamera;
	public Camera fPerson;


	// Use this for initialization
	void Start () {
		fPerson.enabled = false;
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
			transform.Translate(Input.acceleration.x, 0, 0);
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
			score += 5;
			scoreText.text = score + "";
		}
		if (collisionObject.gameObject.CompareTag ("Obstacle")) {
			playSound("crash");
			endGame ();
		}
		// adjust speed according to score
		speed = speed * ((int)(speed / 25) + 1);
	}

	void OnTriggerEnter(Collider collisionObject){
		if (collisionObject.CompareTag ("Radar")) {
			playSound("coin-drop");
			//			GameObject.Destroy (collisionObject.gameObject);
			if (score - 25 > 0) {
				score -= 25;
			} else {
				score = 0;
			}
			scoreText.text = score + "";
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
		deathMenu.ToggleEndMenu(score);
	}

	public void togglePause(){
		// @TODO
		pauseMenu.Toggle();
	}

	public void toggleCamera(){
		// @TODO
		if (mainCamera.isActiveAndEnabled) {
			mainCamera.enabled = false;
			fPerson.enabled = true;
		} else {
			mainCamera.enabled = true;
			fPerson.enabled = false;
		}
	}
}