using UnityEngine;
using System.Collections;
using InControl;

public class CarMovement : MonoBehaviour {
	#region Car Properties
	/// <summary>
	/// The wheel radius.
	/// </summary>
	public float wheelRadius;

	/// <summary>
	/// The center of mass.
	/// </summary>
	public Transform centerOfMass;

	/// <summary>
	/// The car's rigidbody.
	/// </summary>
	private Rigidbody rb;
	#endregion

	private ControllerManager control;

	// Use this for initialization
	void Start () {
		control = ControllerManager.Instance;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.centerOfMass = centerOfMass.localPosition;
	}

	void FixedUpdate () {
		//if (control.RightTrigger.IsPressed || control.LeftTrigger.IsPressed) {
		if (control.IsPressed("RightTrigger") || control.IsPressed("LeftTrigger")) {	
			rb.AddForce (1000 * Vector3.forward * (control.RightTrigger.RawValue - control.LeftTrigger.RawValue));

		}


	}
}
