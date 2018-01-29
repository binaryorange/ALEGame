using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// public variables
	public float MoveSpeed = 10f;
	public float TurnSpeed = 2f;
	[HideInInspector]
	public float Gravity = 0f;
	public float TopGravity = -10f;
	public float GravityMultiplier = 1f;
	public float Jump = 10f;
	public float GroundDistanceFeeler = 0.2f;

	float GroundDistance;

	// our player's CC
	CharacterController Player;

	// our looking vectors, used for current looking directions and to store the previous one
	Vector3 lookDir;
	Vector3 oldLookDir;

	// our input floats
	float moveH;
	float moveV;

	void Start() {
		Player = GetComponent<CharacterController> ();
		GroundDistance = Player.bounds.extents.y;
	}

	// our update method
	void Update() {
		
		// get input
		GetInput();

		// Apply our gravity to the player
		ApplyGravity ();

		// check if we are jumping
		PlayerJump ();

		// Move the player
		MovePlayer();

		// Rotate the player
		RotatePlayer();
	}

	/* *********************************************************
	 *  Our controlling functions, separated for readability   *
	 * *********************************************************/

	/// Gets the input axes and stores it in the defined floats
	void GetInput() {
		moveH = Input.GetAxisRaw("Horizontal"); 
		moveV = Input.GetAxisRaw("Vertical");
	}


	/// Applies the gravity to the player object.
	void ApplyGravity() {
		if (!IsGrounded()) {
			Gravity += TopGravity * GravityMultiplier * Time.deltaTime;
		} else {
			Gravity = 0f;
		}
	}
		
	/// Makes the player Jump, replaces default CharacterController's jump method
	void PlayerJump() {
		if (IsGrounded() && Input.GetButtonDown("Jump")) {
			Gravity += Jump;
		}
	}
		
	/// Move the player with its built-in Move() method
	void MovePlayer() {
		// create our movement vector for player movement
		Vector3 movement = new Vector3 (moveH, Gravity, moveV) * MoveSpeed * Time.deltaTime;

		// move the player using its CharacterController.Move method
		Player.Move (movement);
	}
		
	/// Rotate the player to face the direction its forward vector is pointing at
	void RotatePlayer() {
		// create a looking vector using our input values
		lookDir = new Vector3 (moveH, 0f, moveV);

		// if the input values are not zero, rotate the player, otherwise let it sit at its previous rotation angle
		if (moveH != 0 || moveV != 0) {

			// create a smooth direction to look at using Slerp() (benefits keyboard users, does almost nothing for controller input)
			Vector3 smoothDir = Vector3.Slerp(transform.forward, lookDir, TurnSpeed * Time.deltaTime);

			// rotate the player
			transform.rotation = Quaternion.LookRotation (smoothDir);

			// store the current smooth direction to use when the player is not providing input,
			// keeping it rotated to its current angle
			oldLookDir = smoothDir;
		} else {
			transform.rotation = Quaternion.LookRotation(oldLookDir);
		}
	}

		
	/// Determines whether the player is grounded.
	public bool IsGrounded() {
		return Physics.Raycast (transform.position, -Vector3.up, GroundDistance + GroundDistanceFeeler);
	}
}

