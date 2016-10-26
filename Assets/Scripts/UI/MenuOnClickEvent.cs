using UnityEngine;
using System.Collections;

public class MenuOnClickEvent : MonoBehaviour {

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
