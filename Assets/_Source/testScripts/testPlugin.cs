using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlugin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StateManager.Instance.Player.testPlugin.SetPluginName ("test");
		StateManager.Instance.Player.testPlugin.SetPluginAction(Plugin.PluginAction.IncreaseMaximumHealth);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
