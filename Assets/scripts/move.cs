using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour {
	public GameObject player;
	private float speed = 1.0f;
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
}