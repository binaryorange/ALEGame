using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debugger : MonoBehaviour {

	public GameObject PlayerToDebug;
	public GameObject DebugUIText;
	public TextMeshProUGUI Gravity;
	public TextMeshProUGUI Grounded;
	public TextMeshProUGUI Position;
	public TextMeshProUGUI ActivePlugin;
	public TextMeshProUGUI IsFlying;
	public TextMeshProUGUI LastY;

	PlayerController pc;

	bool flip;

	// Use this for initialization
	void Start () {

		flip = true;
		// set DebugUI to inactive by default
		DebugUIText.SetActive(flip);
		pc = PlayerToDebug.GetComponent<PlayerController> ();

		
	}
	
	// Update is called once per frame
	void Update () {

		// if debug is active
		if(Input.GetKeyDown(KeyCode.O)) {
			flip = !flip;
			DebugUIText.SetActive (flip);
		}

		// set the text 
		Gravity.text = "Gravity: " + pc.Gravity.ToString();
		Grounded.text = "Grounded: " + pc.IsGrounded ().ToString ();
		Position.text = "Player Position: " + PlayerToDebug.transform.position.ToString ();
		ActivePlugin.text = "Active Plugin: " + StateManager.Instance.Player.GetCurrentSelectedPluginEffect ().ToString();
		IsFlying.text = "Is Flying: " + pc.isFlying.ToString ();
		LastY.text = "Last Y: " + pc.lastY.ToString();
	}
}
