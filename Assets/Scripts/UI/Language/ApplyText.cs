using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ApplyText : MonoBehaviour {
	/// <summary>
	/// The text.
	/// </summary>
	private Text text;

	/// <summary>
	/// Text keys.
	/// </summary>
	public enum textKeys {
		MAIN_MENU_CREDITS,
		MAIN_MENU_EXIT,
		MAIN_MENU_MAIN_MENU,
		MAIN_MENU_OPTIONS,
		MAIN_MENU_PAUSE,
		MAIN_MENU_RESTART,
		MAIN_MENU_SELECT_LEVEL,
		MENU_OPTIONS_GRAPHICS,
		MENU_OPTIONS_VR,
		MENU_OPTIONS_SOUND,
		MENU_OPTIONS_LANGUAGE,
		MENU_OPTIONS_LANGUAGES_CATALAN,
		MENU_OPTIONS_LANGUAGES_ENGLISH,
		MENU_OPTIONS_LANGUAGES_SPANISH
	};

	/// <summary>
	/// The text key.
	/// </summary>
	public textKeys textKey;

	/// <summary>
	/// The old language.
	/// </summary>
	private string _oldLanguage = "";

	/// <summary>
	/// The new language.
	/// </summary>
	private string _newLanguage = "";

	/// <summary>
	/// Raises the enable event.
	/// </summary>
	void OnEnable () {
		text = GetComponent<Text> ();
		_newLanguage = LanguageManager.Instance.GetActualLanguage ();

		if (_oldLanguage != _newLanguage) {
			text.text = LanguageManager.Instance.GetText (textKey.ToString ());
			_oldLanguage = _newLanguage;
		}
	}
}
