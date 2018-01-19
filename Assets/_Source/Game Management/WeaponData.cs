using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

///  WeaponData class. Houses the data necessary for each weapon to operate to specified paremeters.
[Serializable]
public class WeaponData {
	// the basic data
	private bool bPlayerHasInInventory;
	private int MaxAmmo;             // used for BALLISTIC weapons
	private int CurrentAmmo;
	private float MaxEnergy;         // used for ENERGETIC weapons
	private float CurrentEnergy;
	private float Damage;            // the amount of damage the weapon does
	private float Cooldown;          // how long it takes for the weapon to cooldown
	private WeaponGroup Group;
	private WeaponNames Name;

	/// Enum which stores which GROUP the weapon belongs to
	public enum WeaponGroup {
		NONE,
		Ballistic,
		Energy
	};

	/// Enum which stores the NAMES of all the weapons
	public enum WeaponNames {
		NONE,
		// Ballistic weapons
		MissileLauncher,
		Rifle,
		GrenadeLauncher,
		// Energy weapons
		LaserPistol,
		LaserRifle,
		FocusedCannon
	};

	// Setters ===============================================================
	/// Sets if the Player has the weapon in their inventory. If they do, it can be used as long as it has ammo/energy.
	public void SetPlayerHasInInventory(bool State) { bPlayerHasInInventory = State; }

	/// Sets the MAX AMMO for this weapon
	public void SetMaxAmmo(int Amount) { MaxAmmo = Amount; }

	/// Sets the CURRENT AMMO for this weapon
	public void SetCurrentAmmo(int Amount) { CurrentAmmo += Amount; }

	/// Sets the CURRENT ENERGY for this weapon
	public void SetCurrentEnergy(float Amount) { CurrentEnergy += Amount; }

	/// Sets the MAX ENERGY for this weapon
	public void SetMaxEnergy(float Amount) { MaxEnergy = Amount; }

	/// Sets the amount of DAMAGE the weapon does
	public void SetDamageAmount(float Amount) { Damage = Amount;}

	/// Sets the COOLDOWN speed
	public void SetCoolDown(float Amount) { Cooldown = Amount; }

	/// Sets the GROUP the weapon belongs to
	public void SetWeaponGroup(WeaponGroup WeaponGroup) { Group = WeaponGroup; }

	/// Sets the NAME of the weapon
	public void SetWeaponName(WeaponNames WeaponName) { Name = WeaponName; }

	// Getters ===============================================================
	/// Gets if the player has the weapon in their inventory
	public bool GetPlayerHasInInventory() { return bPlayerHasInInventory; }

	/// Gets the MAX AMMO of this weapon
	public int GetMaxAmmo() { return MaxAmmo; }

	/// Gets the CURRENT AMMO of this weapon
	public int GetCurrentAmmo() { return CurrentAmmo; }

	/// Gets the MAX ENERGY of this weapon
	public float GetMaxEnergy() { return MaxEnergy; }

	/// Gets the DAMAGE rate of the weapon
	public float GetDamageAmount() {return Damage; }

	/// Gets the COOLDOWN length of the weapon
	public float GetCoolDown() { return Cooldown; }

	/// Gets the CURRENT ENERGY of this weapon
	public float GetCurrentEnergy() { return CurrentEnergy; }

	/// Gets the GROUP the weapon belongs to
	public WeaponGroup GetWeaponGroup() {
		switch (Group) {
		case WeaponGroup.Ballistic:
			return WeaponGroup.Ballistic;
			break;

		case WeaponGroup.Energy:
			return WeaponGroup.Energy;

		default:
			return WeaponGroup.NONE;
			break;
		}
	}
		
	/// Gets the name of the weapon as a string
	public string GetWeaponName() {
		switch (Name) {
		case WeaponNames.MissileLauncher:
			return "Missile Launcher";
			break;

		case WeaponNames.Rifle:
			return "Rifle";
			break;

		case WeaponNames.GrenadeLauncher:
			return "Grenade Launcher";
			break;

		case WeaponNames.LaserPistol:
			return "Laser Pistol";
			break;

		case WeaponNames.LaserRifle:
			return "Laser Rifle";
			break;

		case WeaponNames.FocusedCannon:
			return "Focused Cannon";
			break;
		
		default:
			return "NONE";
			Debug.Log ("Nothing found for this weapon. Did you forget to set its properties?");
			break;
		}
	}
}
