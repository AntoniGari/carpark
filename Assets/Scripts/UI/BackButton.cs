using UnityEngine;
using System.Collections;
using InControl;

public class BackButton : MonoBehaviour {

	private MainMenuEvents events;

	public enum BackSelection {
		BACK_BUTTON_MAIN_MENU,
		BACK_BUTTON_OPTIONS
	}; 

	public BackSelection selection;

	// Use this for initialization
	void Start () {
		events = GameObject.Find ("Canvas").GetComponent<MainMenuEvents> ();
	}
	
	// Update is called once per frame
	void Update () {
		var inputDevice = InputManager.ActiveDevice;

		if ((inputDevice.Action2 && inputDevice.Action2.HasChanged) || Input.GetButtonDown ("Cancel")) {
			switch (selection) {
			case BackSelection.BACK_BUTTON_MAIN_MENU:
				events.ReturnMainMenu();
				return;
			case BackSelection.BACK_BUTTON_OPTIONS:
				return;
			}
		}
	}
}
