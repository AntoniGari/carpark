using UnityEngine;
using System.Collections;

public class InGameMenuEvents : MonoBehaviour {

	#region Main Menu GameObjects
	/// <summary>
	/// The main menu GameObject.
	/// </summary>
	public GameObject mainMenu;

	/// <summary>
	/// The options GameObject.
	/// </summary>
	public GameObject options;

	/// <summary>
	/// The VR options GameObject.
	/// </summary>
	public GameObject optionsVR;
	#endregion

	#region Options Menu GameObjects
	/// <summary>
	/// The graphics options GameObject.
	/// </summary>
	public GameObject optionsGraphics;

	/// <summary>
	/// The sound options GameObject.
	/// </summary>
	public GameObject optionsSound;

	/// <summary>
	/// The language options GameObject.
	/// </summary>
	public GameObject optionsLanguage;
	#endregion

	/// <summary>
	/// The back button.
	/// </summary>
	public GameObject backButton;

	#region Actions
	/// <summary>
	/// Changes the language.
	/// </summary>
	/// <param name="language">Language.</param>
	public void ChangeLanguage(string language) {
		LanguageManager.Instance.LoadLanguage(language);
	}

	/// <summary>
	/// Change to the next level.
	/// </summary>
	public void NextLevel() {
		GameManager.Instance.SetNextLevel ();
	}

	/// <summary>
	/// Restarts the level.
	/// </summary>
	public void RestartLevel() {
		GameManager.Instance.RestartLevel();
	}

	/// <summary>
	/// Sets the main menu.
	/// </summary>
	public void SetMainMenu() {
		GameManager.Instance.SetLevel ((GameManager.SceneLevel) GameManager.SceneLevel.LEVEL_MENU);
	}
	#endregion

	#region Back Button
	/// <summary>
	/// Hides the back button.
	/// </summary>
	private void HideBackButton() {
		backButton.SetActive (false);
	}

	/// <summary>
	/// Shows the back button.
	/// </summary>
	private void ShowBackButton() {
		backButton.SetActive (true);
	}
	#endregion

	#region Return Functions
	/// <summary>
	/// Returns to the main menu.
	/// </summary>
	public void OpenInGameMenu () {
		mainMenu.SetActive (true);
		options.SetActive (false);
		optionsVR.SetActive (false);
		ShowBackButton ();
	}

	/// <summary>
	/// Opens the options menu.
	/// </summary>
	public void OpenOptionsMenu() {
		mainMenu.SetActive (false);
		options.SetActive (true);
		optionsLanguage.SetActive (false);
		optionsVR.SetActive (false);
	}

	/// <summary>
	/// Returns into the options menu.
	/// </summary>
	public void CloseInGameMenu () {
		mainMenu.SetActive (false);
		HideBackButton ();
	}
	#endregion

	#region Select Main Menu
	/// <summary>
	/// Selects the VR options.
	/// </summary>
	public void SelectOptions () {
		mainMenu.SetActive (false);
		options.SetActive (true);
	}

	/// <summary>
	/// Selects the VR options.
	/// </summary>
	public void SelectVROptions () {
		mainMenu.SetActive (false);
		options.SetActive (false);
		optionsVR.SetActive (true);
	}
	#endregion

	#region Select Options Menu
	/// <summary>
	/// Selects the graphics menu.
	/// </summary>
	public void SelectGraphicsMenu () {
		mainMenu.SetActive (false);
		options.SetActive (false);
		optionsGraphics.SetActive (true);
	}

	/// <summary>
	/// Selects the language menu.
	/// </summary>
	public void SelectLanguageMenu () {
		mainMenu.SetActive (false);
		options.SetActive (false);
		optionsLanguage.SetActive (true);
	}


	/// <summary>
	/// Selects the sound menu.
	/// </summary>
	public void SelectSoundMenu () {
		options.SetActive (false);
		optionsSound.SetActive (true);
	}
	#endregion

	#region Virtual Reality
	/// <summary>
	/// Toggles the distortion correction.
	/// </summary>
	public void ToggleDistortionCorrection() {
		GvrViewer.Instance.DistortionCorrectionEnabled = !GvrViewer.Instance.DistortionCorrectionEnabled;
	}

	/// <summary>
	/// Toggles the VR mode.
	/// </summary>
	public void ToggleVRMode() {
		GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
	}
	#endregion
}