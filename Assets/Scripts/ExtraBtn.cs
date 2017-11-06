using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBtn : MonoBehaviour {
	public PauseMenu pauseMenu;

	public Camera mainCamera;
	public Camera fPerson;

	// Use this for initialization
	void Start () {
		fPerson.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void togglePause() {
		pauseMenu.Toggle();
	}


	public void toggleCam() {
		if (mainCamera.isActiveAndEnabled) {
			mainCamera.enabled = false;
			fPerson.enabled = true;
		} else {
			mainCamera.enabled = true;
			fPerson.enabled = false;
		}
	}
}