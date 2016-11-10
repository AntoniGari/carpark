using UnityEngine;
using System.Collections;
using InControl;

public class CarMovement : MonoBehaviour {

	public float wheelRadius;

	public Transform centerOfMass;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.centerOfMass = centerOfMass.localPosition;
	}

	void FixedUpdate () {
		var inputDevice = InputManager.ActiveDevice;

		Debug.Log (Input.GetAxisRaw ("Right Trigger"));
		rb.AddForce (1000 * Vector3.forward * Input.GetAxisRaw("Right Trigger"));
	}
}
