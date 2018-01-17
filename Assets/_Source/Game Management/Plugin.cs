using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// Plugins class, used for the player plugin system
public class Plugin {
	/// NAME and BOOLEAN values used to determine what actions the plugin can do
	string Name;
	bool bIsActive;
	bool bIncreasesFlightHeight;
	bool bIncreasesSpeed;
	bool bIncreasesPowerRegen;
	bool bIncreasesMaximumHealth;
	bool bIncreasesHealthRegen;
	bool bDoublesAmmo;

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
			bIncreasesFlightHeight = true;
			Action = PluginAction.IncreaseFlightHeight;
			break;
		default:
			break;
		}
	}
}
