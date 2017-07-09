using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Game manager.
/// </summary>
public class GameManager : MonoBehaviour {

	#region Game Manager Enums
	/// <summary>
	/// Game state.
	/// </summary>
	public enum GameState {
		STATE_INIT_LEVEL,
		STATE_PLAY,
		STATE_ESC,
		STATE_WIN,
		STATE_LOSE
	};

	/// <summary>
	/// Scene level.
	/// </summary>
	public enum SceneLevel {
		LEVEL_MENU,
		LEVEL_1,
		LEVEL_2,
		LEVEL_3,
		LEVEL_4,
		LEVEL_5,
		LEVEL_6,
		LEVEL_7,
		LEVEL_8,
		LEVEL_9,
		LEVEL_10,
		LEVEL_SIZE
	};
	#endregion


	/// <summary>
	/// The state of the game.
	/// </summary>
	[SerializeField]
	private GameState gameState;

	/// <summary>
	/// The scene level.
	/// </summary>
	[SerializeField]
	private SceneLevel sceneLevel;

	/// <summary>
	/// Modify the VR options.
	/// </summary>
	private IEnumerator _changeVROptions;

	/// <summary>
	/// The vR mode enabled.
	/// </summary>
	private bool vRModeEnabled;

	/// <summary>
	/// The distortion correction enabled.
	/// </summary>
	private bool distortionCorrectionEnabled;

	#region Singleton
	/// <summary>
	/// Static instance.
	/// </summary>
	private static GameManager instance = null;

	/// <summary>
	/// Get the singleton instance
	/// </summary>
	public static GameManager Instance {
		get {
			if(instance == null) {
				GameObject go = new GameObject ("Game Manager");
				instance = go.AddComponent<GameManager> ();
				DontDestroyOnLoad(go);
			}	
			return instance;
		}
	}
	#endregion

	#region ScriptableObjects
	/// <summary>
	/// The audio manager.
	/// </summary>
	[HideInInspector]
	public AudioManager audioManager;


	/// <summary>
	/// The controller manager.
	/// </summary>
	[HideInInspector]
	public ControllerManager controllerManager;

	/// <summary>
	/// The language manager.
	/// </summary>
	[HideInInspector]
	public LanguageManager languageManager;

	/// <summary>
	/// The music manager.
	/// </summary>
	[HideInInspector]
	public MusicManager musicManager;
	#endregion

	public void Start () {
		//ScriptableObjects
		audioManager = AudioManager.Instance;
		controllerManager = ControllerManager.Instance;
		languageManager = LanguageManager.Instance;
		musicManager = MusicManager.Instance;
	}


	/// <summary>
	/// Initialize Singleton 
	/// </summary>
	private GameManager() {
		gameState 	= GameState.STATE_INIT_LEVEL;
		sceneLevel	= SceneLevel.LEVEL_MENU;
		_changeVROptions = ChangeVROptions ();
	}

	/// <summary>
	/// Raises the application quit event.
	/// </summary>
	public void OnApplicationQuit() {
		instance = null;
		audioManager = null;
		controllerManager = null;
		languageManager = null;
		musicManager = null;
	}

	/// <summary>
	/// Changes the VR options.
	/// </summary>
	/// <returns>The VR options.</returns>
	private IEnumerator ChangeVROptions() {
		#if UNITY_IOS
		yield return new WaitForSeconds (0.5f);
		#else
		yield return new WaitForSeconds (0.1f);
		#endif

		GvrViewer.Instance.VRModeEnabled = vRModeEnabled;
		GvrViewer.Instance.DistortionCorrectionEnabled = distortionCorrectionEnabled;
	}

	/// <summary>
	/// Gets the level.
	/// </summary>
	/// <returns>The level.</returns>
	public SceneLevel GetLevel() {
		return sceneLevel;
	}

	/// <summary>
	/// Gets the level.
	/// </summary>
	/// <returns>The level.</returns>
	public int GetLevelNumber() {
		return (int)sceneLevel;
	}

	/// <summary>
	/// Gets the state.
	/// </summary>
	/// <returns>The state.</returns>
	public GameState GetState() {
		return gameState;
	}

	public void OnLevelWasLoaded(int level) {
		StartCoroutine (_changeVROptions);
		vRModeEnabled = GvrViewer.Instance.VRModeEnabled;
		distortionCorrectionEnabled = GvrViewer.Instance.DistortionCorrectionEnabled;
	}

	/// <summary>
	/// Restarts the level.
	/// </summary>
	public void RestartLevel() {
		vRModeEnabled = GvrViewer.Instance.VRModeEnabled;
		distortionCorrectionEnabled = GvrViewer.Instance.DistortionCorrectionEnabled;

		AudioManager.Instance.StopFX ();
		SceneManager.LoadScene((int)sceneLevel);
		SetState (GameState.STATE_INIT_LEVEL);

		//StartCoroutine (_changeVROptions);
	}

	/// <summary>
	/// Sets the level.
	/// </summary>
	/// <param name="newLevel">New level.</param>
	public void SetLevel(SceneLevel newLevel) {
		vRModeEnabled = GvrViewer.Instance.VRModeEnabled;
		distortionCorrectionEnabled = GvrViewer.Instance.DistortionCorrectionEnabled;

		sceneLevel = newLevel;
		AudioManager.Instance.StopFX ();
		SceneManager.LoadScene((int)sceneLevel);
		SetState (GameState.STATE_INIT_LEVEL);

		//StartCoroutine (_changeVROptions);
	}

	/// <summary>
	/// Sets the next level.
	/// </summary>
	public void SetNextLevel() {
		vRModeEnabled = GvrViewer.Instance.VRModeEnabled;
		distortionCorrectionEnabled = GvrViewer.Instance.DistortionCorrectionEnabled;

		int nextLevel = GetLevelNumber () + 1;
		sceneLevel = (SceneLevel)nextLevel;

		AudioManager.Instance.StopFX ();
		if (nextLevel < (int)SceneLevel.LEVEL_SIZE) {
			SceneManager.LoadScene((int)sceneLevel);
		} else {
			SceneManager.LoadScene (0);
		}
		SetState (GameState.STATE_INIT_LEVEL);

		//StartCoroutine (_changeVROptions);
	}

	/// <summary>
	/// Sets the state.
	/// </summary>
	/// <param name="newState">New state.</param>
	public void SetState(GameState newState) {
		gameState = newState;
	}
}