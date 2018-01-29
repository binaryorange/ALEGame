using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plugin : MonoBehaviour {

	public PluginData data;
	public GameObject pluginModel;

	void Start() {
		// find what name the plugin has and set its properties automatically (for debug, will not happen at game design stage)
		switch (data.PluginName) {

		case PluginData.PluginNames.IncreaseFlightHeight:
			data.NameForInventory = "Flying High!";
			data.Effect = "increaseflight";
			break;

		case PluginData.PluginNames.IncreaseSpeed:
			data.NameForInventory = "High Gear!";
			data.Effect = "increasespeed";
			break;

		case PluginData.PluginNames.DoubleAmmo:
			data.NameForInventory = "Did somebody say MORE AMMO?!";
			data.Effect = "doubleammo";
			break;
		
		case PluginData.PluginNames.IncreaseMaximumHealth:
			data.NameForInventory = "Healthy as a (Robotic) Horse!";
			data.Effect = "increasemaxhealth";
			break;
		
		case PluginData.PluginNames.IncreaseHealthRegen:
			data.NameForInventory = "Get Well Soon!";
			data.Effect = "increasehealthregen";
			break;
		case PluginData.PluginNames.IncreasePowerRegen:
			data.NameForInventory = "High Voltage!";
			data.Effect = "increasepowerregen";
			break;
		default:
			break;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			// add the plugin to the player's plugin list
			StateManager.Instance.Player.AddPluginToInventory (data); 
			// destroy the instance of the plugin
			Destroy(this.gameObject);
		}
	}
}
