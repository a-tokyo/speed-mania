using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject MainMenuCtr;

	public ExtraMenu credits;
	public ExtraMenu howToPlay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Play (){
		SceneManager.LoadScene ("Game");
	}

	public void ToggleCredits() {
		MainMenuCtr.SetActive (false);
		credits.Toggle();
	}

	public void ToggleHowTo() {
		MainMenuCtr.SetActive (false);
		howToPlay.Toggle();
	}
}
