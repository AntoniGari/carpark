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
	/// The language manager.
	/// </summary>
	[HideInInspector]
	public LanguageManager languageManager;

	/// <summary>
	/// The controller manager.
	/// </summary>
	[HideInInspector]
	public ControllerManager controllerManager;
	#endregion

	public void Start () {
		//ScriptableObjects
		languageManager = LanguageManager.Instance;
		controllerManager = ControllerManager.Instance;
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
		languageManager = null;
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