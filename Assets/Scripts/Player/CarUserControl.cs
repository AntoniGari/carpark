using UnityEngine;
using System.Collections;

public class CarUserControl : MonoBehaviour {

	private CarController car;

	private ControllerManager control;


	float h;
	float v;
	float handbrake;

	// Use this for initialization
	void Awake() {
		car = GetComponent<CarController>();
		control = ControllerManager.Instance;
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if (control.IsPressed ("Forward") || control.IsPressed ("Back")) {
			Debug.Log ("Something pressed");

			h = 0.0f;
			v = control.RawValue();
			handbrake = control.LeftTrigger.RawValue;

			Debug.Log ("H: " + h + " - V: " + v + " - Handbrake: " + handbrake);
			car.Move (h, v, v, handbrake);
		}
	}
		
}
