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

	/// Enum which stores the CATEGORIES of the plugins
	public enum PluginCategories {
		NONE,
		Regeneration,
		Bonus
	};

	/// Enum which stores the NAMES of the plugins
	public enum PluginActions {
		Default,
		Active,
		IncreaseFlightHeight,
		IncreaseSpeed,
		IncreasePowerRegen,
		IncreaseMaximumHealth,
		IncreaseHealthRegen,
		DoubleAmmo
	};

	private PluginCategories Category;
	private PluginActions Action;

	/// Creates (or enables) and sets the properties of a Plugin object through PluginActions
	public void CreatePlugin(PluginActions ActionToEnable) {
		// Set Action to the user-provided action
		Action = ActionToEnable;

		switch (ActionToEnable) {
		// Increase the default flight height
		case PluginActions.IncreaseFlightHeight:
			Name = "Super Height";
			Category = PluginCategories.Bonus;
			bIncreasesFlightHeight = true;
			break;
		
		// Increase the speed of the player
		case PluginActions.IncreaseSpeed:
			Name = "Charge";
			Category = PluginCategories.Bonus;
			bIncreasesSpeed = true;            
			break;
	
		// Increase rate at which power regenerates
		case PluginActions.IncreasePowerRegen:
			Name = "Power Regeneration Boost";
			Category = PluginCategories.Regeneration;
			bIncreasesPowerRegen = true;       
			break;

		// Increase maximum health
		case PluginActions.IncreaseMaximumHealth:
			Name = "Health Boost";
			Category = PluginCategories.Bonus;
			bIncreasesMaximumHealth = true;
			break;

		// Increase health regeneration speed
		case PluginActions.IncreaseHealthRegen:
			Name = "Speedy Recovery";
			Category = PluginCategories.Regeneration;
			bIncreasesHealthRegen = true;
			break;

		// Doubles ALL ammo in the player's weapon caches
		case PluginActions.DoubleAmmo:
			Name = "Ammunition Doubulation";
			Category = PluginCategories.Bonus;
			bDoublesAmmo = true;
			break;
		default:
			break;
		}
	}

	public string GetName() {
		return Name;
	}

	public PluginCategories GetCategory() {
		return Category;
	}

	public PluginActions GetAction() {
		return Action;
	}
}
