using UnityEngine;
using System.Collections;

public class MainMenuEvents : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject selectLevel;
	public GameObject options;
	public GameObject credits;


	// Use this for initialization
	void Start () {
	
	}

	/// <summary>
	/// Closes the game.
	/// </summary>
	public void CloseGame() {
		Application.Quit ();
	}

	/// <summary>
	/// Returns to the main menu.
	/// </summary>
	public void ReturnMainMenu () {
		credits.SetActive (false);
		selectLevel.SetActive (false);
		options.SetActive (false);
		mainMenu.SetActive (true);
	}

	/// <summary>
	/// Returns into the options menu.
	/// </summary>
	public void ReturnOptions () {
		selectLevel.SetActive (false);
		options.SetActive (false);
		credits.SetActive (false);
		mainMenu.SetActive (true);
	}

	/// <summary>
	/// Selects the level menu.
	/// </summary>
	public void SelectCredits () {
		mainMenu.SetActive (false);
		credits.SetActive (true);
	}

	/// <summary>
	/// Selects the level menu.
	/// </summary>
	public void SelectLevelMenu () {
		mainMenu.SetActive (false);
		selectLevel.SetActive (true);
	}

	/// <summary>
	/// Selects the options menu.
	/// </summary>
	public void SelectOptions () {
		mainMenu.SetActive (false);
		options.SetActive (true);
	}

	/// <summary>
	/// Sets the level.
	/// </summary>
	/// <param name="level">Level.</param>
	public void SetLevel(int level) {
		GameManager.Instance.SetLevel ((GameManager.SceneLevel) level);
	}

	/*
	//TOGGLE PANEL MENU WITH PANEL CREDITS AND BACK
	public void ToggleCredits() {
		panelMenu.SetActive (!panelMenu.activeSelf);
		panelCredits.SetActive (!panelCredits.activeSelf);
	}

	//TOGGLE PANEL MENU WITH PANEL OPTIONS AND BACK
	public void ToggleOptions()
	{
		panelMenu.SetActive (!panelMenu.activeSelf);
		panelOptions.SetActive (!panelOptions.activeSelf);
	}

	//TOGGLE PANEL MENU WITH PANEL CREDITS AND BACK
	public void ToggleLevel()
	{
		panelMenu.SetActive (!panelMenu.activeSelf);
		panelLevel.SetActive (!panelLevel.activeSelf);
	}
	*/
}
