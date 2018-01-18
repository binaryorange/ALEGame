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
	private int CurrentWeapon; // TODO: Make a Weapon class for this field
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

	public void SetCurrentWeapon(int WeaponID) {
		CurrentWeapon = WeaponID;
	}

	public void SetCurrentAmmo(int Ammo) {
		CurrentAmmo += Ammo;
	}

	public void SetCurrentScrews(int Screws) {
		CurrentScrews += Screws;
	}

	public void SetCurrentDooDads(int DooDads) {
		CurrentDooDads += DooDads;
	}

	public void SetCurrentGizmos(int Gizmos) {
		CurrentGizmos += Gizmos;
	}

	public void SetCurrentComponents(int Components){
		CurrentComponents += Components;
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

	public int GetCurrentWeapon() { return CurrentWeapon; }

	public int GetCurrentAmmo() { return CurrentAmmo; }

	public int GetCurrentScrews() { return CurrentScrews; }

	public int GetCurrentDooDads() { return CurrentDooDads; }

	public int GetCurrentGizmos() { return CurrentGizmos; }

	public int GetCurrentComponents() { return CurrentComponents; }

	public Plugin GetCurrentPlugin() { return CurrentPlugin; }
}