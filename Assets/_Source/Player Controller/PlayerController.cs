using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Controller script for the player.
public class PlayerController : MonoBehaviour {

	// declare variables we need
	public GameObject player;
	public float flightHeight = 10f; 
	public float speed = 10f;
	public float jumpHeight = 6.5f;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	[Range (0, 5)]
	public int pluginIndex;

	public PluginData plugin = new PluginData(); // shows what plugin we have in-editor
	public WeaponData weapon = new WeaponData(); // shows what weapon we have in-editor

	Rigidbody rb;


	// Use this for initialization
	void Start () {
		// get the rigidbody off of the player
		rb = player.GetComponent<Rigidbody>();
	}
	
	// use fixed update since we are using physics to drive the player
	void FixedUpdate () {

		plugin = StateManager.Instance.Player.GetCurrentSelectedPluginEffect ();
		

		CheckInput ();
		// control the player
			// moving
			// jumping
			// flying
	}

	void CheckInput() {
		if (Input.GetKeyDown(KeyCode.L)) {
			StateManager.Instance.Player.SetCurrentPlugin (pluginIndex);
			plugin = StateManager.Instance.Player.GetCurrentSelectedPluginEffect ();
		}
	}

	void ChooseWeapon() {
		//TODO: Add weapon choosing code
	}

	void ChoosePlugin(int index) {
	}

	void OnTriggerEnter(Collider other) {
		// batteries

		// ammo

		// screws, doodads and gizmos
	}
}
