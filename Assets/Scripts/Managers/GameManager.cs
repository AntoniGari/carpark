using System.Collections;
using EnumGameState;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Game manager.
/// </summary>
public class GameManager : MonoBehaviour {

	/// <summary>
	/// The instance.
	/// </summary>
	private static GameManager instance;

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
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static GameManager Instance {
		get {
			if(instance == null) {
				GameObject go = new GameObject ("Game State");
				instance = go.AddComponent<GameManager> ();
				DontDestroyOnLoad(go);
			}	
			return instance;
		}
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
	}

	/// <summary>
	/// Gets the level.
	/// </summary>
	/// <returns>The level.</returns>
	public SceneLevel GetLevel() {
		return sceneLevel;
	}

	/// <summary>
	/// Gets the state.
	/// </summary>
	/// <returns>The state.</returns>
	public GameState GetState() {
		return gameState;
	}

	/// <summary>
	/// Sets the level.
	/// </summary>
	/// <param name="newLevel">New level.</param>
	public void SetLevel(SceneLevel newLevel) {
		sceneLevel = newLevel;
		//MusicManager.Instance.StopFX ();
		SceneManager.LoadScene((int)sceneLevel);
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