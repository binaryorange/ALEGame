using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// PlayerData class, used to hold all data for the player object in the game
[Serializable]
public class PlayerData {
	// This bool determines if the currently selected game file is in use
	// If it isn't, we can safely write to it and save it properly
	private bool bIsGameFileInUse;
	// These store what world/level the player is in
	private string WorldName; 
	private string LevelName;

	// These are the player's current attributes, modifiable at runtime
	private int CurrentLevel;
	private float CurrentXP;
	private float CurrentHealth;
	private float CurrentPower;
	private WeaponData.WeaponNames CurrentWeapon;
	private int CurrentAmmo;   // TODO: Make Ammo field a part of the Weapons class
	private int CurrentScrews;
	private int CurrentDooDads;
	private int CurrentGizmos;
	private int CurrentComponents;
	private Plugin CurrentPlugin;

	// Setter methods
	public void SetGameFileInUse(bool state) {
		bIsGameFileInUse = state;
	}
	public void SetWorldName(string Name) {
		WorldName = Name;
	}

	public void SetLevelName(string Name) {
		LevelName = Name;
	}

	public void SetCurrentLevel(int Level) {
		CurrentLevel = Level;
	}

	public void SetCurrentXP(float XP) {
		CurrentXP += XP;
		//TODO: Add code to handle leveling up
	}

	public void SetCurrentHealth(float Health) {
		CurrentHealth += Health;
	}

	public void SetCurrentPower(float Power) {
		CurrentPower += Power;
	}

	public void SetCurrentWeapon(WeaponData.WeaponNames WeaponID) {
		CurrentWeapon = WeaponID;
	}

	public void SetCurrentAmmo(int Ammo) {
		CurrentAmmo += Ammo;
	}

	public void SetCurrentScrews(int Screws) {
		CurrentScrews += Screws;

		// check if we have 100 screws. If we do, add 1 to our DooDads and reset screws
		if(CurrentScrews >= 100) {
			SetCurrentDooDads (1);

			int difference = CurrentScrews - 100;

			CurrentScrews = difference;
		}

		// Make sure we can't go below zero!
		if(CurrentScrews <= 0) { CurrentScrews = 0; }
	}

	public void SetCurrentDooDads(int DooDads) {
		CurrentDooDads += DooDads;

		// check if we have 100 DooDads. If we do, add 1 to our Gizmos and reset DooDads
		if(CurrentDooDads >= 100) {
			SetCurrentGizmos (1);

			int difference = CurrentDooDads - 100;

			CurrentDooDads = difference;
		}

		// Make sure we can't go below zero!
		if(CurrentDooDads <=0 ) { CurrentDooDads = 0; }
	}

	public void SetCurrentGizmos(int Gizmos) {
		CurrentGizmos += Gizmos;

		// check if we have collected 100 Gizmos. If we do, add 1 to our Components and reset Gizmos
		if(CurrentGizmos >= 100) {
			SetCurrentComponents (1);

			int difference = CurrentGizmos - 100;

			CurrentGizmos = difference;
		}

		// Make sure we can't go below zero!
		if(CurrentGizmos <=0) { CurrentGizmos = 0; }
	}

	public void SetCurrentComponents(int Components){
		CurrentComponents += Components;

		// check if we have spent a Component. If we have, reduce the amount
	}

	public void SetCurrentPlugin(Plugin.PluginAction SelectedPlugin) {
		CurrentPlugin.SetPluginAction (SelectedPlugin);
	}

	// Getter methods
	public bool GetGameFileInUse() {return bIsGameFileInUse; }

	public string GetWorldName() { return WorldName; }

	public string GetLevelName() { return LevelName; }

	public int GetCurrentLevel() { return CurrentLevel; }

	public float GetCurrentXP() { return CurrentXP; }

	public float GetCurrentHealth() { return CurrentHealth; }

	public float GetCurrentPower() { return CurrentPower; }

	public WeaponData.WeaponNames GetCurrentWeapon() { return CurrentWeapon; }

	public int GetCurrentAmmo() { return CurrentAmmo; }

	public int GetCurrentScrews() { return CurrentScrews; }

	public int GetCurrentDooDads() { return CurrentDooDads; }

	public int GetCurrentGizmos() { return CurrentGizmos; }

	public int GetCurrentComponents() { return CurrentComponents; }

	public Plugin GetCurrentPlugin() { return CurrentPlugin; }
}