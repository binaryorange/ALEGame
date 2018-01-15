using System.Collections;
using System.Collections.Generic;
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
		GlobalGameManager.Instance.SaveGame ("test");
		Debug.Log ("Saved Game");
	}

	// load the level
	public void Load() {
		GlobalGameManager.Instance.LoadGame ("test");
		Debug.Log ("Load Game");
	}

	// reset values
	public void Reset() {
		GlobalGameManager.Instance.StartNewGame ("test");
	}
}
