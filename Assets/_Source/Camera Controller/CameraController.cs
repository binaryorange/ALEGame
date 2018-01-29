using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject CameraTarget;
	public float Smoothing = 10f;

	public Vector3 offset;

	private Vector3 velocity = Vector3.zero;

	void Start() {
		
	}
	
	// Update the camera's position to look at the player 
	void LateUpdate () {

		Vector3 desiredPosition = CameraTarget.transform.position + offset;
		transform.position = Vector3.SmoothDamp (transform.position, desiredPosition, ref velocity, Smoothing);

	}
}
