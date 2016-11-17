﻿using UnityEngine;
using System.Collections;
using InControl;

public class ControllerManager : ScriptableObject {
	#region Singleton
	/// <summary>
	/// Static instance
	/// </summary>
	private static ControllerManager instance = null;

	/// <summary>
	/// Get the singleton instance
	/// </summary>
	public static ControllerManager Instance {
		get{
			if (instance == null) instance = CreateInstance<ControllerManager>();
			return instance;
		}
	}
	#endregion

	#region Controllers
	/// <summary>
	/// The right trigger.
	/// </summary>
	public InputControl RightTrigger = null;

	/// <summary>
	/// The left trigger.
	/// </summary>
	public InputControl LeftTrigger = null;
	#endregion

	public void Awake() {
		foreach (var inputDevice in InputManager.Devices) {
			bool active = InputManager.ActiveDevice == inputDevice;
			foreach (var control in inputDevice.Controls) {
				if (control != null) {
					if (inputDevice.IsKnown) {
						switch (control.Target.ToString()) {
						case "RightTrigger":
							RightTrigger = control;
							break;
						case "LeftTrigger":
							LeftTrigger = control;
							break;
						}
					}
				}
			}
		}
	}

	/// <summary>
	/// Determines whether this instance is pressed the specified trigger.
	/// </summary>
	/// <returns><c>true</c> if this instance is pressed the specified trigger; otherwise, <c>false</c>.</returns>
	/// <param name="trigger">Trigger.</param>
	public bool IsPressed (string trigger) {
		bool result = false;

		switch (trigger) {
		case "Forward":
			if (RightTrigger != null)
				result = RightTrigger.IsPressed;
			if (Input.GetAxis ("Vertical") > 0)
				result = true;
			break;
		case "RightTrigger":
		case "Right Trigger":
		case "RT":
			if (RightTrigger != null)
				result = RightTrigger.IsPressed;
			break;
		case "Back":
			if (LeftTrigger != null)
				result = LeftTrigger.IsPressed;
			if (Input.GetAxis ("Vertical") < 0)
				result = true;
			break;
		case "LeftTrigger":
		case "Left Trigger":
		case "LT":
			if (LeftTrigger != null)
				result = LeftTrigger.IsPressed;
			break;
		case "Vertical":
			if (Input.GetAxis ("Vertical") != 0)
				result = true;
			break;
		}


		return result;
	}

	/// <summary>
	/// The Raw value.
	/// </summary>
	/// <returns>The value.</returns>
	public float RawValue () {
		float result = 0.0f;

		if (IsPressed("Vertical"))
			result = Input.GetAxis ("Vertical");

		if (IsPressed("RT") || IsPressed("LT"))
			result = RightTrigger.RawValue - LeftTrigger.RawValue;
	
		return result;
	}

	/// <summary>
	/// The Raw value.
	/// </summary>
	/// <returns>The raw value.</returns>
	/// <param name="trigger">Trigger.</param>
	public float RawValue (string trigger) {
		switch (trigger) {
		case "RightTrigger":
		case "Right Trigger":
		case "RT":
			return RightTrigger.RawValue;
		case "LeftTrigger":
		case "Left Trigger":
		case "LT":
			return LeftTrigger.RawValue;
		default:
			return 0.0f;
		}
	}
}