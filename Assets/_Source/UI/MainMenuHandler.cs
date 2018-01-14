using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour {

	/*****************************************************
	 * MainMenuHandler is first script loaded into memory,
	 * therefore we set up GameManager object inside of its
	 * Start() method
	 *****************************************************/
	void Start() {
		GlobalGameManager.Instance.InitializeGameManager();
	}

	// create our start button function
	public void StartGame(string sceneToStart) {

		//load the test level
		DontDestroyOnLoad(GlobalGameManager.Instance.GameManager);
		SceneManager.LoadScene(sceneToStart, LoadSceneMode.Single);
	}
}
