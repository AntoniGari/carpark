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
		//MAIN MENU
		CREDITS,
		MAIN_MENU_CREDITS,
		MAIN_MENU_EXIT,
		MAIN_MENU_MAIN_MENU,
		MAIN_MENU_OPTIONS,
		MAIN_MENU_PAUSE,
		MAIN_MENU_RESTART,
		MAIN_MENU_SELECT_LEVEL,
		MAIN_MENU_NEXT_LEVEL,

		//MENU OPTIONS
		MENU_OPTIONS_GRAPHICS,
		MENU_OPTIONS_VR,
		MENU_OPTIONS_SOUND,
		MENU_OPTIONS_LANGUAGE,

		//MENU OPTIONS GRAPHICS
		MENU_OPTIONS_GRAPHICS_1,
		MENU_OPTIONS_GRAPHICS_2,
		MENU_OPTIONS_GRAPHICS_3,

		//MENU OPTIONS LANGUAGES
		MENU_OPTIONS_LANGUAGES_CATALAN,
		MENU_OPTIONS_LANGUAGES_ENGLISH,
		MENU_OPTIONS_LANGUAGES_SPANISH,

		//MENU OPTIONS SOUND
		MENU_OPTIONS_SOUND_1,
		MENU_OPTIONS_SOUND_2,
		MENU_OPTIONS_SOUND_3,

		//MENU OPTIONS VR
		MENU_OPTIONS_VR_RECENTER,
		MENU_OPTIONS_VR_MODE,
		MENU_OPTIONS_VR_DISTORTION_CORRECTION
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
