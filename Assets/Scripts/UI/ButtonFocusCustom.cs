using UnityEngine;


namespace InterfaceMovementCustom {
	public class ButtonFocusCustom : MonoBehaviour {
		void Update() {
			/// <summary>
			/// Get focused button.
			/// </summary>
			var focusedButton = transform.parent.GetComponent<ButtonManagerCustom>().focusedButton;

			/// <summary>
			/// Move toward same position as focused button.
			/// </summary>
			transform.position = Vector3.MoveTowards( transform.position, focusedButton.transform.position, Time.deltaTime * 10.0f );
		}
	}
}
