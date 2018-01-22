using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	// declare a temporary player data object
	public PlayerData playerItems; // public so we can see it in editor
	public Canvas InventoryObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChoosePlugin() {
		
	}

	/// Called when opening up the inventory menu
	void UpdatePlayerItems() {
		playerItems = StateManager.Instance.GetGlobalPlayerInfo ();	
	}
}
