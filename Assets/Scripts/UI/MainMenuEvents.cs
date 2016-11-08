using UnityEngine;
using System.Collections;

public class MainMenuEvents : MonoBehaviour {

	#region Main Menu GameObjects
	public GameObject mainMenu;
	public GameObject selectLevel;
	public GameObject options;
	public GameObject credits;
	#endregion

	#region Options Menu GameObjects
	public GameObject optionsLanguage;
	public GameObject optionsSound;
	public GameObject optionsVR;
	#endregion

	public GameObject backButton;

	// Use this for initialization
	void Start () {
	
	}

	#region Actions
	/// <summary>
	/// Changes the language.
	/// </summary>
	/// <param name="language">Language.</param>
	public void ChangeLanguage(string language) {
		LanguageManager.Instance.LoadLanguage(language);
	}

	/// <summary>
	/// Closes the game.
	/// </summary>
	public void CloseGame() {
		Application.Quit ();
	}

	/// <summary>
	/// Sets the level.
	/// </summary>
	/// <param name="level">Level.</param>
	public void SetLevel(int level) {
		GameManager.Instance.SetLevel ((GameManager.SceneLevel) level);
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
	public void ReturnMainMenu () {
		credits.SetActive (false);
		selectLevel.SetActive (false);
		options.SetActive (false);
		mainMenu.SetActive (true);
		HideBackButton ();
	}

	/// <summary>
	/// Returns into the options menu.
	/// </summary>
	public void ReturnOptions () {
		optionsLanguage.SetActive (false);
		//optionsSound.SetActive (false);
		optionsVR.SetActive (false);
		options.SetActive (true);
	}
	#endregion

	#region Select Menus
	/// <summary>
	/// Selects the level menu.
	/// </summary>
	public void SelectCredits () {
		mainMenu.SetActive (false);
		credits.SetActive (true);
		ShowBackButton ();
	}

	/// <summary>
	/// Selects the language menu.
	/// </summary>
	public void SelectLanguageMenu () {
		options.SetActive (false);
		optionsLanguage.SetActive (true);
	}

	/// <summary>
	/// Selects the level menu.
	/// </summary>
	public void SelectLevelMenu () {
		mainMenu.SetActive (false);
		selectLevel.SetActive (true);
		ShowBackButton ();
	}

	/// <summary>
	/// Selects the options menu.
	/// </summary>
	public void SelectOptions () {
		mainMenu.SetActive (false);
		options.SetActive (true);
		ShowBackButton ();
	}

	/// <summary>
	/// Selects the VR options.
	/// </summary>
	public void SelectVROptions () {
		options.SetActive (false);
		optionsVR.SetActive (true);
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