using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using UnityEngine.UI;

public class ControllerHelper : MonoBehaviour {

	public Text coordenadesX;
	public Text coordenadesY;

	private void Awake() {

		#if UNITY_IOS
		ICadeDeviceManager.Active = true;
		#endif
	}


	public float GetLeftStickX() {
		var inputDevice = InputManager.ActiveDevice;
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
