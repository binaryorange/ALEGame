using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	// uses the player's transform for the raycast origin
	public GameObject player;
	public GameObject WeaponModel;

	// Creates a new instance of the weapon data class
	public WeaponData weaponData;

	void Start() {

		// automatically set the weapon tag depending on the weapon's name
		switch (weaponData.Name) {
		case WeaponData.WeaponNames.MissileLauncher:
			WeaponModel.tag = "Missile Launcher";
			break;
		case WeaponData.WeaponNames.Rifle:
			WeaponModel.tag = "Rifle";
			break;
		case WeaponData.WeaponNames.GrenadeLauncher:
			WeaponModel.tag = "Grenade Launcher";
			break;
		case WeaponData.WeaponNames.LaserPistol:
			WeaponModel.tag = "Laser Pistol";
			break;
		case WeaponData.WeaponNames.LaserRifle:
			WeaponModel.tag = "Laser Rifle";
			break;
		case WeaponData.WeaponNames.FocusedCannon:
			WeaponModel.tag = "Focused Cannon";
			break;
		default:
			break;
		}
	}

	void Update() {
		if (Input.GetButton ("Fire1")) {
			FireWeapon ();
		}
	}


	public void FireWeapon() {
		// start the raycast
		RaycastHit hit;
		// fire the weapon depending on what group it belongs to
		switch(weaponData.Group) {
		case WeaponData.WeaponGroup.Ballistic:
			
			if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, 100f)) {
				
			}
			break;
		case WeaponData.WeaponGroup.Energy:
			break;
		}

	}

	public void ReloadWeapon() {
		//TODO: Add reloading code here
	}
}
