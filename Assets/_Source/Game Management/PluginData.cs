using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

/// Plugins class, used for the player plugin system
[Serializable]
public class PluginData {
	// values used to determine what actions the plugin can do
	public PluginNames PluginName;
	[HideInInspector]
	public bool bIsActive = false;
	[HideInInspector]
	public bool bPlayerHasInInventory = false;
	public int PluginID;
	public string NameForInventory;
	public string Description;
	public string Effect;

	/// Enum which stores the NAMES of the plugins, used in-editor to easily create the plugin gameobject
	public enum PluginNames {
		IncreaseFlightHeight,
		IncreaseSpeed,
		IncreasePowerRegen,
		IncreaseMaximumHealth,
		IncreaseHealthRegen,
		DoubleAmmo
	};
}
