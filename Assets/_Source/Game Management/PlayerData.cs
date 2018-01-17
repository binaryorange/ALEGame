using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
// PlayerData class, used to hold all data for the player object in the game
public class PlayerData {
	// This bool determines if the currently selected game file is in use
	// If it isn't, we can safely use it
	public bool bIsGameFileInUse;
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
	public Plugin testPlugin;

	//TODO: getters
	//TODO: setters
}