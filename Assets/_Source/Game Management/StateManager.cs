using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;
/// This is the StateManager. It's a global singleton class that handles all of the
/// data inside of the game. Creates a single Player object that's accessed through the StateManager.Instance.Player syntax
public class StateManager : MonoBehaviour {
	/* StateManager class will handle all data in the game, persistent and temporary.
	 * File handling for Save Games will be handled in FileManager.cs.
	 * Player Controller will call getters/setters from this script to handle things such
	 * as health status, powerup useages and other types of persistent data through the Player object */

	// This is the reference to the manager's instance
	private static StateManager instance;

	// this is the reference to manager GameObject
	public GameObject GameManager;

	// This will create an instance if there isn't one already
	public static StateManager Instance {
		get {
			if (instance == null) {
				instance = new GameObject ("StateManager").AddComponent<StateManager> ();
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
	 * NOTE: See "PlayerData" class to see all the attributes the Player has access to
	 * ************************************************************************************/

	// create a new PlayerData object
	public PlayerData Player = new PlayerData();

	/**************************************************************************************
	 * These functions handle the StateManager states at runtime
	 **************************************************************************************/

	// This initializes the game manager, which for now stores the GameManager gameobject so it can't be destroyed between scenes
	public void InitializeGameManager() {
		GameManager = GameObject.Find ("StateManager");
		GameManager.tag = "StateManager";
	}

	/// Sets/udpates the GLOBAL Player object held in the State Manager. Called when loading new levels/changing scenes.
	public void SetGlobalPlayerInfo(PlayerData InfoToUpdate) {
		Player = InfoToUpdate;
	}

	/// Gets the data from the GLOBAL Player object held in the State Manager.
	public PlayerData GetGlobalPlayerInfo() {
		return Player;
	}
		
}
