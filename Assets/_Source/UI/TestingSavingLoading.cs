using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingSavingLoading : MonoBehaviour {

	// call the SetCurrentXP method
	public void IncreaseXP() {
		GlobalGameManager.Instance.Player.SetCurrentXP (1);
		Debug.Log ("Player XP now at: " + GlobalGameManager.Instance.Player.GetCurrentXP ());
	}

	public void DecreaseXP() {
		GlobalGameManager.Instance.Player.SetCurrentXP (-1);
		Debug.Log ("Player XP now at: " + GlobalGameManager.Instance.Player.GetCurrentXP ());
	}

	// find out what level we're in
	public void GetLevelName() {
		Debug.Log("Level name: " + GlobalGameManager.Instance.Player.GetLevelName ());
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
}
