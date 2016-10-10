using UnityEngine;
using System.Collections;

/// <summary>
/// It's a Enumeration of the Game State and the Scene Level
/// </summary>
namespace EnumGameState {
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
		LEVEL_7
	};
}