using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using InControl;

/// <summary>
/// Button custom.
/// </summary>
namespace InterfaceMovementCustom {
	public class ButtonCustom : MonoBehaviour {
		/// <summary>
		/// Up Button.
		/// </summary>
		public ButtonCustom up = null;

		/// <summary>
		/// Down Button.
		/// </summary>
		public ButtonCustom down = null;

		/// <summary>
		/// The left Button.
		/// </summary>
		public ButtonCustom left = null;

		/// <summary>
		/// The right Button.
		/// </summary>
		public ButtonCustom right = null;

		/// <summary>
		/// The focused text.
		/// </summary>
		public Text text;

		/// <summary>
		/// The click Event.
		/// </summary>
		public UnityEvent onClick;

		void Update() {
			/// <summary>
			/// Find out if we're the focused button.
			/// </summary>
			bool hasFocus = transform.parent.GetComponent<ButtonManagerCustom>().focusedButton == this;
			text.color = hasFocus ? Color.white : Color.black;
			text.fontStyle = hasFocus ? FontStyle.Bold : FontStyle.Normal;
		}

		/// <summary>
		/// Raises the click event.
		/// </summary>
		public void OnClick(){
			onClick.Invoke();
		}
	}
}