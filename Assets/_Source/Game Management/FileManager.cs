using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;


public class FileManager {

	/* This is the class that handles all file data for the game */

	// The NEW GAME method
	public void NewGame (string GameFile, PlayerData PlayerInfoToCreate) {
		// first check if the game file is in use
		if (!IsSelectedGameFileInUse (GameFile)) {
			// initialize the default game values, and then save the file so that these values are
			// stored into memory properly
			PlayerInfoToCreate.SetGameFileInUse(true); // what we use to determine if the file is blank or not, for debug purposes
			PlayerInfoToCreate.SetWorldName("test");
			PlayerInfoToCreate.SetLevelName("test");
			PlayerInfoToCreate.SetCurrentLevel(1);
			PlayerInfoToCreate.SetCurrentXP(0.0f);
			PlayerInfoToCreate.SetCurrentHealth(100.0f);
			PlayerInfoToCreate.SetCurrentPower(100.0f);
			PlayerInfoToCreate.SetCurrentWeapon(WeaponData.WeaponNames.NONE);
			PlayerInfoToCreate.SetCurrentAmmo(0);
			PlayerInfoToCreate.SetCurrentScrews(0);
			PlayerInfoToCreate.SetCurrentDooDads(0);
			PlayerInfoToCreate.SetCurrentGizmos(0);
			PlayerInfoToCreate.SetCurrentComponents(0);
			PlayerInfoToCreate.SetCurrentPlugin (Plugin.PluginActions.Default);

			// now save the file to disk
			SaveGame(GameFile, PlayerInfoToCreate);

			//TODO: figure out how we want to handle first-time level transitioning when starting a new game
		}
	}
	
	// The SAVE GAME method
	public void SaveGame (string GameFile, PlayerData PlayerInfoToSave) {
		// create a binary formatter and file path
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath+"/"+GameFile);

		// serialize the file
		bf.Serialize(file, PlayerInfoToSave);
		file.Close ();
		
	}

	// The LOAD GAME method
	public void LoadGame (string GameFile) {
		// check to see if the game file exists
		if(File.Exists(Application.persistentDataPath+"/"+GameFile)) {
			// create a binary formatter and file path to read from
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open (Application.persistentDataPath+"/"+GameFile, FileMode.Open);
			PlayerData pData = (PlayerData)bf.Deserialize (file);
			file.Close ();

			// pass the data from pData back to the main player object
			StateManager.Instance.Player = pData;
		}
	}

	// Check to see if a game file is currently in use
	public bool IsSelectedGameFileInUse (string GameFile) {
		// open the file if it exists and grab the "InUse" bool
		if (File.Exists (GameFile)) {
			FileStream file = new FileStream (Application.persistentDataPath + "/" + GameFile, FileMode.Open);
			BinaryFormatter bf = new BinaryFormatter ();

			PlayerData data = (PlayerData)bf.Deserialize (file);

			return data.GetGameFileInUse();

		} else {
			Debug.Log ("File not found, returning FALSE");
			return false;
		}
	}

	// This method overwrites the existing save file, replacing it with NOTHING
	public void OverwriteGameFile(string GameFile) {
		
	}
}


