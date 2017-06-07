using UnityEngine;
using System.Collections;
using InControl;
using UnityStandardAssets.Vehicles.Car;

public class InGameMenu : MonoBehaviour {
	/// <summary>
	/// The events.
	/// </summary>
	private InGameMenuEvents events;

	/// <summary>
	/// The car controller.
	/// </summary>
	private CarUserControl carControl;

	/// <summary>
	/// Back selection.
	/// </summary>
	public enum InGameMenuSelection {
		IN_GAME_MENU_OPEN_CLOSE_MENU,
		IN_GAME_MENU_IN_GAME_MENU
	};

	/// <summary>
	/// The enum selection.
	/// </summary>
	public InGameMenuSelection selection;

	/// <summary>
	/// Changes the event.
	/// </summary>
	private bool _change_event;

	// Use this for initialization
	void Start () {
		events = GameObject.FindGameObjectWithTag("Canvas").GetComponent<InGameMenuEvents> ();
		carControl = GameObject.FindGameObjectWithTag ("Player").GetComponent<CarUserControl> ();
		_change_event = true;
	}

	// Update is called once per frame
	void Update () {
		var inputDevice = InputManager.ActiveDevice;

		if ((inputDevice.Action2 && inputDevice.Action2.HasChanged) || Input.GetButtonDown ("Cancel")) {
			switch (selection) {
			case InGameMenuSelection.IN_GAME_MENU_OPEN_CLOSE_MENU:
				if (_change_event) {
					carControl.Brake ();
					carControl.enabled = false;
					events.OpenInGameMenu ();
				} else {
					events.CloseInGameMenu ();
					carControl.enabled = true;
				}
				_change_event = !_change_event;
				return;
			case InGameMenuSelection.IN_GAME_MENU_IN_GAME_MENU:
				events.OpenInGameMenu ();
				return;
			}
		}
	}
}
