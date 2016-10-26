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
		public ButtonCustom up = null;
		public ButtonCustom down = null;
		public ButtonCustom left = null;
		public ButtonCustom right = null;
		public Text text;
		public UnityEvent onClick;

		void Update() {
			/// <summary>
			/// Find out if we're the focused button.
			/// </summary>
			bool hasFocus = transform.parent.GetComponent<ButtonManagerCustom>().focusedButton == this;
			text.color = hasFocus ? Color.white : Color.black;
			text.fontStyle = hasFocus ? FontStyle.Bold : FontStyle.Normal;
		}

		public void OnClick(){
			onClick.Invoke();
		}
	}
}