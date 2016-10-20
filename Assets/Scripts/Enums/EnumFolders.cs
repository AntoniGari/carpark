using System;
using UnityEngine;

public static class EnumFolders {
	#region Private attributes
	/// <summary>
	/// Assets' folder.
	/// </summary>
	private static string _assetsFolder = "Assets";

	/// <summary>
	/// Languages' Folder
	/// </summary>
	private static string _languagesFolder = "Languages";

	/// <summary>
	/// The resources folder.
	/// </summary>
	private static string _resourcesFolder = "Resources";

	/// <summary>
	/// Template's folder.
	/// </summary>
	private static string _templateFolder = "Template";
	#endregion

	#region Methods
	/// <summary>
	/// Gets the assets folder.
	/// </summary>
	/// <returns>The assets folder.</returns>
	public static string getAssetsFolder() {
		return _assetsFolder;
	}

	/// <summary>
	/// Gets the assets path.
	/// </summary>
	/// <returns>The assets path.</returns>
	public static string getAssetsPath() {
		return _assetsFolder + "/";
	}

	/// <summary>
	/// Gets the languages folder.
	/// </summary>
	/// <returns>The languages folder.</returns>
	public static string getLanguagesFolder() {
		return _languagesFolder;
	}

	/// <summary>
	/// Gets the languages path.
	/// </summary>
	/// <returns>The languages path.</returns>
	public static string getLanguagesPath() {
		return getResourcesPath() + _languagesFolder + "/";
	}

	/// <summary>
	/// Gets the resources folder.
	/// </summary>
	/// <returns>The resources folder.</returns>
	public static string getResourcesFolder() {
		return _resourcesFolder;
	}

	/// <summary>
	/// Gets the resources path.
	/// </summary>
	/// <returns>The resources path.</returns>
	public static string getResourcesPath() {
		return getAssetsPath() + _resourcesFolder + "/";
	}

	/// <summary>
	/// Gets the template folder.
	/// </summary>
	/// <returns>The template folder.</returns>
	public static string getTemplateFolder() {
		return _templateFolder;
	}

	/// <summary>
	/// Gets the template path.
	/// </summary>
	/// <returns>The template path.</returns>
	public static string getTemplatePath() {
		return getLanguagesPath() + _templateFolder + "/";
	}
	#endregion
}