using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlayerControllerTest : MonoBehaviour {
	public float inputDelay = 0.1f; 
	public float forwardVel = 12f;
	public float rotateVel = 100f;

	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, turnInput;

	public Quaternion TargetRotation {

		get { return targetRotation; }
	}

	void Start () {
		targetRotation = transform.rotation;
		rBody = GetComponent<Rigidbody> ();

		forwardInput = turnInput = 0f;
	}

	void GetInput () {
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}
		
	void FixedUpdate () {
		GetInput ();
		Run ();
		Turn ();
	}

	void Run () {
		if (Mathf.Abs (forwardInput) > inputDelay) {
			rBody.velocity = transform.forward * forwardInput * forwardVel;

		} else
			rBody.velocity = Vector3.zero;
	}

	void Turn() {
		if (Mathf.Abs(turnInput) > inputDelay) {
			targetRotation *= Quaternion.AngleAxis (rotateVel * turnInput * Time.deltaTime, Vector3.up);
		}

		transform.rotation = targetRotation;
	}
}
