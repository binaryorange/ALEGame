using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TestingSavingLoading : MonoBehaviour {

	FileManager FileManager = new FileManager();

	// call the SetCurrentXP method
	public void IncreaseXP() {
		StateManager.Instance.Player.SetCurrentXP(1);
		Debug.Log ("Player XP now at: " + StateManager.Instance.Player.GetCurrentXP());
	}

	public void DecreaseXP() {
		StateManager.Instance.Player.SetCurrentXP(-1);
		Debug.Log ("Player XP now at: " + StateManager.Instance.Player.GetCurrentXP());
	}

	// find out what level we're in
	public void GetLevelName() {
		Debug.Log("Level name: " + StateManager.Instance.Player.GetLevelName());
	}

	// save the level
	public void Save() {
		FileManager.SaveGame (StateManager.Instance.GetSelectedGameFile (), StateManager.Instance.Player);
		Debug.Log ("Saved Game");
	}

	// load the level
	public void Load() {
		FileManager.LoadGame (StateManager.Instance.GetSelectedGameFile());
		Debug.Log ("Load Game");
	}

	// reset values
	public void Reset() {
		FileManager.NewGame (StateManager.Instance.GetSelectedGameFile(), StateManager.Instance.Player);
	}

	// select game files
	public void SetGame(string GameName) {
		StateManager.Instance.SetSelectedGameFile (GameName+".alesf");

		Debug.Log ("Game File set to " + StateManager.Instance.GetSelectedGameFile());
	}

	public void SetValues() {
		StateManager.Instance.Player.SetCurrentGizmos (2);
		StateManager.Instance.Player.SetCurrentDooDads (99);
		StateManager.Instance.Player.SetCurrentScrews (15);
	}
	public void AddScrew() {
		StateManager.Instance.Player.SetCurrentScrews (1);
		Debug.Log ("Screws: " + StateManager.Instance.Player.GetCurrentScrews().ToString() + " : DooDads: " + StateManager.Instance.Player.GetCurrentDooDads().ToString() + " : Gizmos: " + StateManager.Instance.Player.GetCurrentGizmos().ToString());
	}

	public void RemoveGizmo() {
		StateManager.Instance.Player.SetCurrentGizmos (-1);
		Debug.Log ("Screws: " + StateManager.Instance.Player.GetCurrentScrews().ToString() + " : DooDads: " + StateManager.Instance.Player.GetCurrentDooDads().ToString() + " : Gizmos: " + StateManager.Instance.Player.GetCurrentGizmos().ToString());
	}

	public void RemoveDooDad() {
		StateManager.Instance.Player.SetCurrentDooDads (-1);
		Debug.Log ("Screws: " + StateManager.Instance.Player.GetCurrentScrews().ToString() + " : DooDads: " + StateManager.Instance.Player.GetCurrentDooDads().ToString() + " : Gizmos: " + StateManager.Instance.Player.GetCurrentGizmos().ToString());
	}


}
