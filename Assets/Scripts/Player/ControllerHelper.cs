using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.UI;

public class ControllerHelper : MonoBehaviour {

	public Text name;
	public Text coordenadesX;
	public Text coordenadesY;

	private float _h;
	private float _v;

	void Awake() {
		_h = 0.0f;
		_v = 0.0f;

		#if UNITY_IOS
		ICadeDeviceManager.Active = true;
		#endif
	}

	void Update() {
		var inputDevice = InputManager.ActiveDevice;

		name.text = inputDevice.Name;

		var controlX = inputDevice.LeftStickX;
		coordenadesX.text = string.Format( "{0} {1}", "Left Stick X = ", controlX.Value);
		_h = controlX.Value;

		var controlY = inputDevice.LeftStickY;
		coordenadesY.text = string.Format( "{0} {1}", "Left Stick Y = ", controlY.Value);
		_v = controlY.Value;
	}


	public float GetLeftStickX() {
		var inputDevice = InputManager.ActiveDevice;

		name.text = inputDevice.Name;

		var controlX = inputDevice.LeftStickX;
		coordenadesX.text = string.Format( "{0} {1}", "Left Stick X = ", controlX.Value);

		return controlX.Value;
	}

	public float GetLeftStickY() {
		var inputDevice = InputManager.ActiveDevice;
		var controlY = inputDevice.LeftStickY;
		coordenadesY.text = string.Format( "{0} {1}", "Left Stick Y = ", controlY.Value);
		return controlY.Value;
	}
}
