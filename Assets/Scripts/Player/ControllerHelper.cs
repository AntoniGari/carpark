using UnityEngine;
using UnityEngine.UI;
using InControl;

public class ControllerHelper : MonoBehaviour {
	/// <summary>
	/// The name text.
	/// </summary>
	public Text name;

	/// <summary>
	/// The coordenades x text.
	/// </summary>
	public Text coordenadesX;

	/// <summary>
	/// The coordenades y text.
	/// </summary>
	public Text coordenadesY;

	/// <summary>
	/// The height.
	/// </summary>
	private float _h;

	/// <summary>
	/// The vertical component.
	/// </summary>
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
}