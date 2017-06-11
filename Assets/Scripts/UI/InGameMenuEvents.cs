using UnityEngine;
using System.Collections;

public class InGameMenuEvents : MonoBehaviour {

	#region Main Menu GameObjects
	public GameObject mainMenu;
	public GameObject options;
	public GameObject optionsVR;
	#endregion

	#region Options Menu GameObjects
	public GameObject optionsGraphics;
	public GameObject optionsSound;
	public GameObject optionsLanguage;
	#endregion

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
		//GameManager.Instance.SetLevel ((GameManager.SceneLevel) GameManager.Instance.GetLevelNumber());
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
		optionsVR.SetActive (true);
	}
	#endregion

	#region Select Options Menu
	/// <summary>
	/// Selects the graphics menu.
	/// </summary>
	public void SelectGraphicsMenu () {
		options.SetActive (false);
		optionsGraphics.SetActive (true);
	}

	/// <summary>
	/// Selects the language menu.
	/// </summary>
	public void SelectLanguageMenu () {
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