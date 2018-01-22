using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

///  WeaponData class. Houses the data necessary for each weapon to operate to specified paremeters.
[Serializable]
public class WeaponData {
	// the basic data
	public bool bPlayerHasInInventory;
	public bool bIsSelected;
	public WeaponNames Name;
	public WeaponGroup Group;
	public int MaxAmmo;                 // used for BALLISTIC weapons
	public int MaxClips;
	public int CurrentClips;            // determines how many clips of ammo the player has
	public int CurrentAmmo;
	public float MaxEnergy;             // used for ENERGETIC weapons
	public int MaxBatteries;
	public float CurrentBatteries;      // determines how many times the player can recharge energy weapons
	public float CurrentEnergy;
	public float FireRate;
	public float DamageRate;            // the amount of damage the weapon does
	public float CooldownRate;          // how long it takes for the weapon to cooldown


	/// Enum which stores which GROUP the weapon belongs to
	public enum WeaponGroup {
		NONE,
		Ballistic,
		Energy
	};

	/// Enum which stores the NAMES of all the weapons
	public enum WeaponNames {
		// Ballistic weapons
		MissileLauncher,
		Rifle,
		GrenadeLauncher,
		// Energy weapons
		LaserPistol,
		LaserRifle,
		FocusedCannon
	};
}
