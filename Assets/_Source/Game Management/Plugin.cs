using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// Plugins class, used for the player plugin system
[Serializable]
public class Plugin {
	/// NAME and BOOLEAN values used to determine what actions the plugin can do
	private string Name;
	private bool bIsActive = false;
	private bool bIncreasesFlightHeight = false;
	private bool bIncreasesSpeed = false;
	private bool bIncreasesPowerRegen = false;
	private bool bIncreasesMaximumHealth = false;
	private bool bIncreasesHealthRegen = false;
	private bool bDoublesAmmo = false;

	/// Enum which is used to determine what values should be turned to true on the plugin object
	public enum PluginAction {
		Default,
		Active,
		IncreaseFlightHeight,
		IncreaseSpeed,
		IncreasePowerRegen,
		IncreaseMaximumHealth,
		IncreaseHealthRegen,
		DoubleAmmo
	};

	private PluginAction Action;

	// set the name and the first action
	public void SetPluginName(string PluginName) {
		Name = PluginName;
	}

	public void SetPluginAction(PluginAction ActionToEnable) {
	
		switch (ActionToEnable) {
		case PluginAction.IncreaseFlightHeight:
			bIncreasesFlightHeight = true;       // Increase the default flight height
			break;

		case PluginAction.IncreaseSpeed:
			bIncreasesSpeed = true;              // Increase the speed of the player
			break;

		case PluginAction.IncreasePowerRegen:
			bIncreasesPowerRegen = true;         // Increase rate at which power regenerates
			break;

		case PluginAction.IncreaseMaximumHealth:
			bIncreasesMaximumHealth = true;      // Increase maximum health
			break;
		
		case PluginAction.IncreaseHealthRegen:
			bIncreasesHealthRegen = true;        // Increase health regeneration speed
			break;

		case PluginAction.DoubleAmmo:
			bDoublesAmmo = true;                 // Doubles ALL ammo in the player's weapon caches
			break;
		default:
			break;
		}

		// set the Action variable to the selected action
		Action = ActionToEnable;
	}
}
