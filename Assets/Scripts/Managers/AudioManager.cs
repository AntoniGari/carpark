using UnityEngine;
using System.Collections;

/// <summary>
/// Audio manager.
/// </summary>
public class AudioManager : MonoBehaviour {

	/// <summary>
	/// The instance.
	/// </summary>
	private static AudioManager instance;

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static AudioManager Instance {
		get {
			if(instance == null) {
				GameObject go = new GameObject ("Audio Manager");
				instance = go.AddComponent<AudioManager> ();
				DontDestroyOnLoad(go);
			}	
			return instance;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="AudioManager"/> class.
	/// </summary>
	private AudioManager(){
	}

	public void StopFX() {
	}
}
