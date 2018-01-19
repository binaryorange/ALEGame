using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TestingSavingLoading : MonoBehaviour {

	FileManager FileManager = new FileManager();
	PlayerData Player = StateManager.Instance.Player;

	// call the SetCurrentXP method
	public void IncreaseXP() {
		StateManager.Instance.Player.SetCurrentXP(1);
		Debug.Log ("Player XP now at: " + Player.GetCurrentXP());
	}

	public void DecreaseXP() {
		StateManager.Instance.Player.SetCurrentXP(-1);
		Debug.Log ("Player XP now at: " + Player.GetCurrentXP());
	}

	// find out what level we're in
	public void GetLevelName() {
		Debug.Log("Level name: " + Player.GetLevelName());
	}

	// save the level
	public void Save() {
		StateManager.Instance.Player = Player;
		FileManager.SaveGame (StateManager.Instance.GetSelectedGameFile (), Player);
		Debug.Log ("Saved Game");
	}

	// load the level
	public void Load() {
		FileManager.LoadGame (StateManager.Instance.GetSelectedGameFile());
		Player = StateManager.Instance.Player;
		Debug.Log ("Load Game");
	}

	// reset values
	public void Reset() {
		FileManager.NewGame (StateManager.Instance.GetSelectedGameFile(), Player);
	}

	// select game files
	public void SetGame(string GameName) {
		StateManager.Instance.SetSelectedGameFile (GameName+".alesf");

		Debug.Log ("Game File set to " + StateManager.Instance.GetSelectedGameFile());
	}

	public void SetValues() {
		Player.SetCurrentGizmos (5);
		Player.SetCurrentDooDads (3);
		Player.SetCurrentScrews (2);
	}
	public void AddScrew() {
		Player.SetCurrentScrews (1);
		Debug.Log ("Screws: " + Player.GetCurrentScrews().ToString() + " : DooDads: " + Player.GetCurrentDooDads().ToString() + " : Gizmos: " + Player.GetCurrentGizmos().ToString());
	}

	public void RemoveGizmo() {
		Player.SetCurrentGizmos (-1);
		Debug.Log ("Screws: " + Player.GetCurrentScrews().ToString() + " : DooDads: " + Player.GetCurrentDooDads().ToString() + " : Gizmos: " + Player.GetCurrentGizmos().ToString());
	}

	public void RemoveDooDad() {
		StateManager.Instance.Player.SetCurrentDooDads (-1);
		Debug.Log ("Screws: " + StateManager.Instance.Player.GetCurrentScrews().ToString() + " : DooDads: " + StateManager.Instance.Player.GetCurrentDooDads().ToString() + " : Gizmos: " + StateManager.Instance.Player.GetCurrentGizmos().ToString());
	}


}
