using UnityEngine;
using System.Collections;

public class MainMenuEvents : MonoBehaviour {
	#region Main Menu GameObjects
	/// <summary>
	/// The main menu GameObject.
	/// </summary>
	public GameObject mainMenu;

	/// <summary>
	/// The select level GameObject.
	/// </summary>
	public GameObject selectLevel;

	/// <summary>
	/// The options GameObject.
	/// </summary>
	public GameObject options;

	/// <summary>
	/// The credits GameObject.
	/// </summary>
	public GameObject credits;
	#endregion

	#region Options Menu GameObjects
	/// <summary>
	/// The options graphics GameObject.
	/// </summary>
	public GameObject optionsGraphics;

	/// <summary>
	/// The VR options GameObject.
	/// </summary>
	public GameObject optionsVR;

	/// <summary>
	/// The Sound options GameObject.
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
		optionsGraphics.SetActive (false);
		optionsSound.SetActive (false);
		optionsVR.SetActive (false);
		options.SetActive (true);
	}
	#endregion

	#region Select Main Menu Options
	/// <summary>
	/// Selects the level menu.
	/// </summary>
	public void SelectCredits () {
		mainMenu.SetActive (false);
		credits.SetActive (true);
		ShowBackButton ();
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

	/// <summary>
	/// Selects the VR options.
	/// </summary>
	public void SelectVROptions () {
		options.SetActive (false);
		optionsVR.SetActive (true);
	}
	#endregion

	#region Sound Options
	/// <summary>
	/// Changes the FX volume.
	/// </summary>
	/// <param name="increase">If set to <c>true</c> increase.</param>
	public void ChangeFXVolume (bool increase){
		if (increase)
			GameManager.Instance.audioManager.IncreaseVolume ();
		else
			GameManager.Instance.audioManager.DecreaseVolume (); 
	}

	/// <summary>
	/// Changes the music volume.
	/// </summary>
	/// <param name="increase">If set to <c>true</c> increase.</param>
	public void ChangeMusicVolume (bool increase){
		if (increase)
			GameManager.Instance.musicManager.IncreaseVolume ();
		else {
			GameManager.Instance.musicManager.DecreaseVolume (); 
		}
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