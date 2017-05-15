using UnityEngine;
using UnityEngine.UI;
using InControl;

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

		//name.text = inputDevice.Name;

		if (inputDevice.IsKnown) {
			var control = inputDevice.LeftStickX;
			name.text = control.Value.ToString();
		}

		var controlX = inputDevice.LeftStickX;
		_h = controlX.Value;
		coordenadesX.text = string.Format( "{0} {1}", "Left Stick X = ", _h);


		var controlY = inputDevice.LeftStickY;
		_v = controlY.Value;
		coordenadesY.text = string.Format( "{0} {1}", "Left Stick Y = ", _v);

	}

	/*
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
	*/
}
