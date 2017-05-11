using UnityEngine;
using InControl;


namespace InterfaceMovementCustom {
	public class ButtonManagerCustom : MonoBehaviour {
		public ButtonCustom focusedButton;

		TwoAxisInputControl filteredDirection;

		void Awake() {
			filteredDirection = new TwoAxisInputControl();
			filteredDirection.StateThreshold = 0.5f;

			#if UNITY_IOS
			ICadeDeviceManager.Active = true;
			#endif
		}

		void Update() {
			// Use last device which provided input.
			var inputDevice = InputManager.ActiveDevice;
			filteredDirection.Filter( inputDevice.Direction, Time.deltaTime );
		
			if (filteredDirection.Left.WasRepeated) {
				Debug.Log( "!!!" );
			}

			// Move focus with directional inputs.
			if (filteredDirection.Up.WasPressed || Input.GetKeyDown (KeyCode.W)) {
				MoveFocusTo( focusedButton.up );
			}

			if (filteredDirection.Down.WasPressed || Input.GetKeyDown (KeyCode.S)) {
				MoveFocusTo( focusedButton.down );
			}

			if (filteredDirection.Left.WasPressed || Input.GetKeyDown (KeyCode.A)) {
				MoveFocusTo( focusedButton.left );
			}

			if (filteredDirection.Right.WasPressed || Input.GetKeyDown (KeyCode.D)) {
				MoveFocusTo( focusedButton.right );
			}

			if ((inputDevice.Action1 && inputDevice.Action1.HasChanged) || Input.GetButtonDown ("Submit")) {
				focusedButton.OnClick ();
			}
		}


		void MoveFocusTo( ButtonCustom newFocusedButton ) {
			if (newFocusedButton != null) {
				focusedButton = newFocusedButton;
			}
		}
	}
}