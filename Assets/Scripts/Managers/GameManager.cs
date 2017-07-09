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

		//NEW
		vRModeEnabled = false;
		distortionCorrectionEnabled = true;
	}


	/// <summary>
	/// Initialize Singleton 
	/// </summary>
	private GameManager() {
		gameState 	= GameState.STATE_INIT_LEVEL;
		sceneLevel	= SceneLevel.LEVEL_MENU;
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

	public void ChangeVROpt() {
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


	void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		ChangeVROpt ();
	}

	/// <summary>
	/// Changes the VR mode.
	/// </summary>
	/// <param name="change">If set to <c>true</c> change.</param>
	public void changeVRMode(bool change) {
		vRModeEnabled = change;
	}

	/// <summary>
	/// Changes the distortion correction.
	/// </summary>
	/// <param name="change">If set to <c>true</c> change.</param>
	public void changeDistortionCorrection(bool change) {
		distortionCorrectionEnabled = change;
	}

	/// <summary>
	/// Restarts the level.
	/// </summary>
	public void RestartLevel() {
		AudioManager.Instance.StopFX ();
		SceneManager.LoadScene((int)sceneLevel);
		SetState (GameState.STATE_INIT_LEVEL);
	}

	/// <summary>
	/// Sets the level.
	/// </summary>
	/// <param name="newLevel">New level.</param>
	public void SetLevel(SceneLevel newLevel) {
		sceneLevel = newLevel;
		AudioManager.Instance.StopFX ();
		SceneManager.LoadScene((int)sceneLevel);
		SetState (GameState.STATE_INIT_LEVEL);
	}

	/// <summary>
	/// Sets the next level.
	/// </summary>
	public void SetNextLevel() {
		int nextLevel = GetLevelNumber () + 1;
		sceneLevel = (SceneLevel)nextLevel;

		AudioManager.Instance.StopFX ();
		if (nextLevel < (int)SceneLevel.LEVEL_SIZE) {
			SceneManager.LoadScene((int)sceneLevel);
		} else {
			SceneManager.LoadScene (0);
		}
		SetState (GameState.STATE_INIT_LEVEL);
	}

	/// <summary>
	/// Sets the state.
	/// </summary>
	/// <param name="newState">New state.</param>
	public void SetState(GameState newState) {
		gameState = newState;
	}
}