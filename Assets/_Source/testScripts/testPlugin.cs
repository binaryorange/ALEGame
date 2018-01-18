using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlugin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StateManager.Instance.Player.SetCurrentPlugin(Plugin.PluginAction.IncreaseFlightHeight);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
