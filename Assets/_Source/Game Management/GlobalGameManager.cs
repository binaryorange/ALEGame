using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour {
	/* GlobalGameManager class will handle all data in the game, persistent and temporary.
	 * File handling for Save Games will pass through here for easier accessibility.
	 * Player Controller will call getters/setters from this script to handle things such
	 * as health status, powerup useages and other types of persistent data. 
	 * NOTE: See bottom of file for PlayerData class which is used to save data */

	// This is the reference to the manager's instance
	private static GlobalGameManager instance;

	// this is the reference to manager GameObject
	public GameObject GameManager;

	// This will create an instance if there isn't one already
	public static GlobalGameManager Instance {
		get {
			if (instance == null) {
				instance = new GameObject ("GlobalGameManager").AddComponent<GlobalGameManager> ();
			}

			return instance;
		}
	}

	// destroy the instance on quitting
	public void OnApplicationQuit(){
		instance = null;
	}

	/**************************************************************************************
	 * These variables are used to determine what game file the player has selected in
	 * the main menu at the start of the game
	 **************************************************************************************/
	private string SelectedGameFile;

	// this sets the selected game file
	public void SetSelectedGameFile(string UserSelectedGameFile) {
		SelectedGameFile = UserSelectedGameFile;
	}

	// this returns the currently selected game file
	public string GetSelectedGameFile() {
		return SelectedGameFile;
	}

	/**************************************************************************************
	 * NOTE: See "PlayerData" class at bottom of file to see all the attributes the Player
	 * object has access to
	 * ************************************************************************************/

	// create a new PlayerData object
	public PlayerData Player = new PlayerData();

	/**************************************************************************************
	 * These functions handle the GlobalGameManager states at runtime
	 **************************************************************************************/

	// This initializes the game manager, which for now stores the GameManager gameobject so it can't be destroyed between scenes
	public void InitializeGameManager() {
		GameManager = GameObject.Find ("GlobalGameManager");
		GameManager.tag = "GlobalGameManager";
	}

	// This starts a new game
	public void StartNewGame(string SelectedGameFile) {
		// initialize new game variables
		Player.WorldName = "";
		Player.LevelName = "test";
		Player.CurrentLevel = 1;
		Player.CurrentXP = 0;
		Player.CurrentHealth = 100;
		Player.CurrentPower = 100;
		Player.CurrentWeapon = 0;
		Player.CurrentAmmo = 0;
		Player.CurrentScrews = 0;
		Player.CurrentDooDads = 0;
		Player.CurrentGizmos = 0;
		Player.CurrentComponents = 0;

		Debug.Log ("Values Reset");
	}

	// This loads a game
	public void LoadGame(string SelectedGameFile) {
		// check to see if the game file exists
		if(File.Exists(Application.persistentDataPath+"/"+SelectedGameFile)) {
			// create a binary formatter and file path to read from
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath+"/"+SelectedGameFile, FileMode.Open);
			PlayerData pData = (PlayerData)bf.Deserialize (file);
			file.Close ();

			// pass the data from pData back to the main player object
			Player = pData;
		}
	}

	// This saves a game
	public void SaveGame(string SelectedGameFile) {
		// create a binary formatter and file path
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath+"/"+SelectedGameFile);

		// serialize the file
		bf.Serialize(file, Player);
		file.Close ();
	}
}

[Serializable]
public class PlayerData
{
	// These store what world/level the player is in
	public string WorldName; 
	public string LevelName;

	// These are the player's current attributes, modifiable at runtime
	public int CurrentLevel;
	public int CurrentXP;
	public int CurrentHealth;
	public int CurrentPower;
	public int CurrentWeapon;
	public int CurrentAmmo;  // NOTE: May change to array later to store different types of ammo
	public int CurrentScrews;
	public int CurrentDooDads;
	public int CurrentGizmos;
	public int CurrentComponents;
	public bool[] CurrentPlugins; 
}
