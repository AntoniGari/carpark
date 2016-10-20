using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LanguageManager : ScriptableObject {
	#region Language Configuration
	/// <summary>
	/// Default Language
	/// </summary>
	private string _defaultLanguage = SystemLanguage.English.ToString();

	/// <summary>
	/// Names of the supported languages
	/// </summary>
	private string[] languages = {
		SystemLanguage.Catalan.ToString(),
		SystemLanguage.English.ToString(),
		SystemLanguage.Spanish.ToString()
	};

	/// <summary>
	/// The text files.
	/// </summary>
	private List<string> _txtFiles;
	#endregion

	#region Private attributes
	/// <summary>
	/// Dictionary with the keys and string
	/// </summary>
	private Dictionary<string, string> _textTable;

	/// <summary>
	/// Path of the stored languages
	/// </summary>
	private string _languagesPath;

	/// <summary>
	/// Path of the language template
	/// </summary>
	private string _templatePath;

	#endregion

	#region Singleton
	/// <summary>
	/// Static instance
	/// </summary>
	private static LanguageManager instance = null;

	/// <summary>
	/// Get the singleton instance
	/// </summary>
	public static LanguageManager Instance {
		get{
			if (instance == null) instance = CreateInstance<LanguageManager>();
			return instance;
		}
	}
	#endregion


	#region Methods
	/// <summary>
	/// Recolect all the supported languages
	/// </summary>
	public void Awake() {
		_languagesPath = EnumFolders.getLanguagesPath();
		_templatePath = EnumFolders.getTemplatePath();

		_textTable = new Dictionary<string, string>();
		_txtFiles = new List<string>();

		//Load the *.txt names files
		DirectoryInfo dir = new DirectoryInfo(_templatePath);
		FileInfo[] info = dir.GetFiles("*.txt");
		foreach (FileInfo f in info)
			_txtFiles.Add(f.Name);

		/*string actualLanguage = PlayerPrefs.GetString(OptionsKey.Language, "none");
		if (actualLanguage.CompareTo("none") == 0)
			actualLanguage = Application.systemLanguage.ToString();

		LoadLanguage(actualLanguage);
		*/

		LoadLanguage (_defaultLanguage);
	}

	/// <summary>
	/// Get the text matching the key
	/// </summary>
	/// <param name="key">key of the string</param>
	/// <returns>The string matching with the key</returns>
	public string GetText(string key) {
		if (key != null && _textTable != null) {
			if (_textTable.ContainsKey(key))
				key = _textTable[key];
		}
	
		return key;
	}

	/// <summary>
	/// Get all available languages
	/// </summary>
	/// <returns>List of languages' names</returns>
	public string[] GetLanguages() {
		return languages;
	}

	/// <summary>
	/// Load a language
	/// </summary>
	/// <param name="language">Name of language</param>
	private void LoadLanguage(string language) {
		string line;
		string[] values;
		bool firstLine = true;

		_textTable.Clear();

		foreach (string file in _txtFiles) {
			// Create a new StreamReader, tell it which file to read and what encoding the file was saved as
			StreamReader theReader = new StreamReader (EnumFolders.getLanguagesPath() + language + "/" + file, Encoding.UTF8);
			firstLine = true;

			using (theReader) {
				do {
					if (file != "Credits.txt") {
						line = theReader.ReadLine ();
					} else {
						line = theReader.ReadToEnd();
					}

					if (line != null) {
						if (!firstLine) {
							values = line.Split ('\t');
							//add the entry
							_textTable.Add(values[0], values[1]);
						} else {
							firstLine = false;
							if (file == "Credits.txt") {
								_textTable.Add("CREDITS", line);
								line = null;
							}
						}
					}
				} while (line != null);
			}
			theReader.Close ();
		}
	}
	#endregion
}