using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBPlayerController : MonoBehaviour {

	public float inputDelay = 0.1f;
	public float forwardVelocity = 12f;
	public float rotateVelocity = 100f;

	Quaternion targetRotation;
	Rigidbody rb;
	float forwardInput;
	float turnInput;

	/// <summary>
	/// Gets the target rotation. Useful for future camera controls if needed.
	/// </summary>
	/// <value>The target rotation.</value>
	public Quaternion TargetRotation {
		get { return targetRotation; }
	}

	// Use this for initialization
	void Start () {
		targetRotation = transform.rotation;
		rb = GetComponent<Rigidbody> ();
	}

	void GetInput() {
		forwardInput = Input.GetAxis ("Vertical");
		turnInput = Input.GetAxis ("Horizontal");
	}
	
	// Update is called once per frame
	void Update () {

		// Get input and turn
		GetInput();
		Turn ();
		
	}

	void FixedUpdate() {
		// Call run
		Run();
	}

	void Run() {
		if (Mathf.Abs (forwardInput) > inputDelay) {
			rb.velocity = transform.forward * forwardInput * forwardVelocity;
		} else {
			rb.velocity = Vector3.zero;
		}
	}

	void Turn() {
		if (Mathf.Abs (turnInput) > inputDelay) {
			targetRotation *= Quaternion.AngleAxis (rotateVelocity * turnInput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetRotation;
	}
}
