using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// PlayerData class, used to hold all data for the player object in the game
[Serializable]
public class PlayerData {
	// This bool determines if the currently selected game file is in use
	// If it isn't, we can safely write to it and save it properly
	private bool bInUse;

	// These store what world/level the player is in
	private string WorldName; 
	private string LevelName;

	// These are the player's current attributes, modifiable at runtime
	private int CurrentLevel;
	private float CurrentXP;
	private float CurrentHealth;
	private float CurrentPower;
	private WeaponData CurrentWeapon;
	private int CurrentScrews;
	private int CurrentDooDads;
	private int CurrentGizmos;
	private PluginData CurrentPlugin = new PluginData();

	// these booleans are used to determine what WEAPONS are available for the player to switch to
	private bool bPlayerHasMissileLauncher = false;
	private bool bPlayerHasRifle = false;
	private bool bPlayerHasGrenadeLauncher = false;
	private bool bPlayerHasLaserPistol = false;
	private bool bPlayerHasLaserRifle = false;
	private bool bPlayerHasFocusedCannon = false;

	// these lists determine what the player has in their inventory
	private int WeaponListIndex;
	private int CurrentPluginListIndex;
	public List<WeaponData> WeaponsList = new List<WeaponData>();
	public List<PluginData> PluginsList = new List<PluginData>();

	// Setter methods
	public void SetGameFileInUse(bool state) { bInUse = state; }

	public void SetWorldName(string Name) { WorldName = Name; }

	public void SetLevelName(string Name) { LevelName = Name; }

	public void SetCurrentLevel(int Level) { CurrentLevel = Level; }

	public void SetCurrentXP(float XP) {
		CurrentXP += XP;
		//TODO: Add code to handle leveling up
	}

	public void SetCurrentHealth(float Health) { CurrentHealth += Health; }

	public void SetCurrentPower(float Power) { CurrentPower += Power; }

	public void SetCurrentWeapon(WeaponData WeaponID) { CurrentWeapon = WeaponID; }
		
	public void SetCurrentScrews(int Screws) {
		CurrentScrews += Screws;

		// check if we have 25 screws. If we do, add 1 to our DooDads and reset screws
		if(CurrentScrews >= 25) {
			SetCurrentDooDads (1);

			int difference = CurrentScrews - 100;

			CurrentScrews = difference;
		}

		// Make sure we can't go below zero!
		if(CurrentScrews <= 0) { CurrentScrews = 0; }
	}

	public void SetCurrentDooDads(int DooDads) {
		CurrentDooDads += DooDads;

		// check if we have 50 DooDads. If we do, add 1 to our Gizmos and reset DooDads
		if(CurrentDooDads >= 50) {
			SetCurrentGizmos (1);

			int difference = CurrentDooDads - 50;

			CurrentDooDads = difference;
		}

		// Make sure we can't go below zero!
		if(CurrentDooDads <=0 ) { CurrentDooDads = 0; }
	}

	public void SetCurrentGizmos(int Gizmos) { CurrentGizmos += Gizmos; }
		
	public void SetCurrentPlugin(int nextPluginID) { 

		// check to make sure we aren't switching to the same thing!
		if (nextPluginID == CurrentPluginListIndex) {
			Debug.Log ("Already selected!");
		} else {
			// deactivate the current plugin and activate the new one
			Debug.Log ("Changing from " + CurrentPlugin.NameForInventory + " to " + PluginsList [nextPluginID].NameForInventory);

			PluginsList [CurrentPlugin.PluginID].bIsActive = false;
			// activate the chosen plugin
			PluginsList [nextPluginID].bIsActive = true;

	
			// update the current plugin and index
			CurrentPlugin = PluginsList [nextPluginID];
			CurrentPluginListIndex = nextPluginID;
		}
	}

	// public void SetPluginListIndex(int index) { CurrentPluginListIndex = index; }

	public void AddWeaponToInventory(WeaponData NewWeapon) { WeaponsList.Add (NewWeapon); }

	public void AddPluginToInventory(PluginData NewPlugin) {
		NewPlugin.PluginID = PluginsList.Count;  // makes the plugin ID use the next available ID from the list
		NewPlugin.bIsActive = false;             // makes sure we don't accidentally activate the effect right away
		NewPlugin.bPlayerHasInInventory = true;  // lets the INVENTORY manager script see the plugin

		PluginsList.Add (NewPlugin);
		int index = PluginsList.Count - 1;
		Debug.Log ("Name: " + PluginsList[index].NameForInventory + ". Description: "+ PluginsList[index].Description + ". Plugin ID: " + PluginsList[index].PluginID.ToString() + ". Effect:  "+PluginsList[index].Effect);
	}
		
	// Getter methods
	public bool GetGameFileInUse() { return bInUse; }

	public string GetWorldName() { return WorldName; }

	public string GetLevelName() { return LevelName; }

	public int GetCurrentLevel() { return CurrentLevel; }

	public float GetCurrentXP() { return CurrentXP; }

	public float GetCurrentHealth() { return CurrentHealth; }

	public float GetCurrentPower() { return CurrentPower; }

	public WeaponData GetCurrentSelectedWeapon() { return WeaponsList[WeaponListIndex]; }

	public int GetCurrentScrews() { return CurrentScrews; }

	public int GetCurrentDooDads() { return CurrentDooDads; }

	public int GetCurrentGizmos() { return CurrentGizmos; }

	public PluginData GetCurrentSelectedPluginEffect() { return CurrentPlugin; }


}