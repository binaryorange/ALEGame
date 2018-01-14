using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour {
	/* GlobalGameManager class will handle all data in the game, persistent and temporary.
	 * File handling for Save Games will pass through here for easier accessibility.
	 * Player Controller will call getters/setters from this script to handle things such
	 * as health status, powerup useages and other types of persistent data. */

	// This is the reference to the manager
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
	 * These are the values that are needed to be stored in order for the game to function
	 * properly. All are private unless otherwise noted
	 * ************************************************************************************/
	// These store what world/level the player is in
	private int WorldIndex; 
	private int LevelIndex;

	// These are the player's current attributes, modifiable at runtime
	private int CurrentLevel;
	private int CurrentXP;
	private int CurrentHealth;
	private int CurrentPower;
	private int CurrentWeapon;
	private int CurrentAmmo;  // NOTE: May change to array later to store different types of ammo

	/**************************************************************************************
	 * These functions handle the GlobalGameManager creation at runtime
	 **************************************************************************************/

	// This starts the state, which for now stores the GameManager object so it can't be destroyed between scenes
	public void StartState() {
		GameManager = GameObject.Find ("GlobalGameManager");
		GameManager.tag = "GlobalGameManager";
	}

	// This starts a new game
	public void StartNewGame() {
		// TODO: add NEW GAME details here
	}

	// This loads a game
	public void LoadGame() {
		// TODO: add LOAD GAME details here
	}

	// This saves a game
	public void SaveGame() {
		// TODO: add SAVE GAME details here
	}
}
