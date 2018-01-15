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
		// TODO: add NEW GAME details here
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
	private string WorldName; 
	private string LevelName;

	// These are the player's current attributes, modifiable at runtime
	private int CurrentLevel;
	private int CurrentXP;
	private int CurrentHealth;
	private int CurrentPower;
	private int CurrentWeapon;
	private int CurrentAmmo;  // NOTE: May change to array later to store different types of ammo
	private int CurrentScrews;
	private int CurrentDooDads;
	private int CurrentGizmos;
	private int CurrentComponents;
	private bool[] CurrentPlugins; 

	/**************************************************************************************
	 * These are the getters and setters for the player's attributes
	 **************************************************************************************/

	// setters
	public void SetWorldName(string Name) {
		WorldName = Name;
	}

	public void SetLevelName(string Name) {
		LevelName = Name;
	}

	public void SetCurrentLevel(int Amount) {
		CurrentLevel += Amount;	
	}

	public void SetCurrentXP(int Amount) {
		CurrentXP += Amount;
		// TODO: Add level incrementing when XP reaches target XP
	}

	public void SetCurrentHealth(int Amount) {
		CurrentHealth += Amount;
	}

	public void SetCurrentPower(int Amount) {
		CurrentPower += Amount;
	}

	public void SetCurrentWeapon (int WeaponID) {
		CurrentWeapon = WeaponID;
	}

	public void SetCurrentAmmo (int Amount) {
		CurrentAmmo += Amount;
	}

	public void SetCurrentScrews(int Amount) {
		CurrentScrews += Amount;
	}

	public void SetCurrentDooDads(int Amount) {
		CurrentDooDads += Amount;
	}

	public void SetCurrentGizmos(int Amount) {
		CurrentGizmos += Amount;
	}

	public void SetCurrentComponents(int Amount) {
		CurrentComponents += Amount;
	}

	public void SetCurrentPlugin () {
		//TODO: Figure out how to make plugins work
	}

	// Getters
	public string GetWorldName() { return WorldName; }
	public string GetLevelName() { 
		Scene scene = SceneManager.GetActiveScene ();
		return scene.name;
	}
	public int GetCurrentLevel() { return CurrentLevel; }
	public int GetCurrentXP() { return CurrentXP; }
	public int GetCurrentHealth() { return CurrentHealth; }
	public int GetCurrentPower() { return CurrentPower; }
	public int GetCurrentWeapon() { return CurrentWeapon; }
	public int GetCurrentAmmo() { return CurrentAmmo; }
	public int GetCurrentScrews() { return CurrentScrews; }
	public int GetCurrentDooDads() { return CurrentDooDads; }
	public int GetCurrentGizmos() { return CurrentGizmos; }
	public int GetCurrentComponents() { return CurrentComponents; }
}
