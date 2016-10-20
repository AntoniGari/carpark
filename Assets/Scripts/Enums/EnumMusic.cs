using UnityEngine;
using System.Collections;

/// <summary>
/// Music Enumeration.
/// </summary>
namespace EnumMusic {

	/// <summary>
	/// Music type.
	/// </summary>
	public enum MusicType {
		MUSIC_TYPE_GEEK,
		MUSIC_TYPE_INDIE,
		MUSIC_TYPE_ROCK,
		NO_MUSIC
	};

	/// <summary>
	/// Broadcast.
	/// </summary>
	struct Broadcast {
		/// <summary>
		/// A Radio Broadcast Type with geek style.
		/// </summary>
		public enum BroadCastGeek {
			MUSIC_GEEK_01,
			MUSIC_GEEK_02,
			MUSIC_GEEK_03,
			MUSIC_GEEK_04,
			MUSIC_GEEK_05
		}

		/// <summary>
		/// A Radio Broadcast Type with indie style.
		/// </summary>
		public enum BroadCastIndie {
			MUSIC_INDIE_01,
			MUSIC_INDIE_02,
			MUSIC_INDIE_03,
			MUSIC_INDIE_04,
			MUSIC_INDIE_05
		}

		/// <summary>
		/// A Radio Broadcast Type with Rock style.
		/// </summary>
		public enum BroadCastRock {
			MUSIC_ROCK_01,
			MUSIC_ROCK_02,
			MUSIC_ROCK_03,
			MUSIC_ROCK_04,
			MUSIC_ROCK_05
		}
	}
}