using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TestingSavingLoading : MonoBehaviour {

	// call the SetCurrentXP method
	public void IncreaseXP() {
		GlobalGameManager.Instance.Player.CurrentXP += 1;
		Debug.Log ("Player XP now at: " + GlobalGameManager.Instance.Player.CurrentXP);
	}

	public void DecreaseXP() {
		GlobalGameManager.Instance.Player.CurrentXP -= 1;
		Debug.Log ("Player XP now at: " + GlobalGameManager.Instance.Player.CurrentXP);
	}

	// find out what level we're in
	public void GetLevelName() {
		Debug.Log("Level name: " + GlobalGameManager.Instance.Player.LevelName);
	}

	// save the level
	public void Save() {
		GlobalGameManager.Instance.SaveGame (GlobalGameManager.Instance.GetSelectedGameFile());
		Debug.Log ("Saved Game");
	}

	// load the level
	public void Load() {
		GlobalGameManager.Instance.LoadGame (GlobalGameManager.Instance.GetSelectedGameFile());
		Debug.Log ("Load Game");
	}

	// reset values
	public void Reset() {
		GlobalGameManager.Instance.StartNewGame (GlobalGameManager.Instance.GetSelectedGameFile());
	}

	// select game files
	public void SetGame(string GameName) {
		GlobalGameManager.Instance.SetSelectedGameFile (GameName+".alesf");

		Debug.Log ("Game File set to " + GlobalGameManager.Instance.GetSelectedGameFile());
	}
}
