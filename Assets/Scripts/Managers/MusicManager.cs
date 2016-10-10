using UnityEngine;
using System.Collections;
using EnumGameState;

public class MusicManager : MonoBehaviour {

	/// <summary>
	/// The instance.
	/// </summary>
	private static MusicManager instance;

	/// <summary>
	/// The array music.
	/// </summary>
	public Object[] arrayMusic;

	/// <summary>
	/// The music source.
	/// </summary>
	private AudioSource _musicSource;

	/// <summary>
	/// The music volume.
	/// </summary>
	private float _musicVolume;

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static MusicManager Instance {
		get {
			if(instance == null) {
				GameObject go = new GameObject ("Music Manager");
				instance = go.AddComponent<MusicManager> ();
				DontDestroyOnLoad(go);
			}	
			return instance;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="MusicManager"/> class.
	/// </summary>
	private MusicManager(){
		_musicVolume = 1;
	}

	/// <summary>
	/// Gets the music volume.
	/// </summary>
	/// <returns>The music volume.</returns>
	public float GetMusicVolume(){
		return 	_musicVolume;
	}

	/// <summary>
	/// Determines whether this instance is playing.
	/// </summary>
	/// <returns><c>true</c> if this instance is playing; otherwise, <c>false</c>.</returns>
	public bool IsPlaying(){
		return _musicSource.isPlaying;
	}

	/// <summary>
	/// Loads the audio files.
	/// </summary>
	public void LoadAudioFiles() {
		arrayMusic =  Resources.LoadAll("Audio/Music", typeof(AudioClip));
	}

	/// <summary>
	/// Plaies the music.
	/// </summary>
	public void PlayMusic () {
		_musicSource.Play();
	}

	/// <summary>
	/// Plaies the music.
	/// </summary>
	/// <param name="actualScene">Actual scene.</param>
	public void PlayMusic (SceneLevel actualScene) {
		GetCameraSource ();
		_musicSource.clip = arrayMusic [(int)actualScene] as AudioClip;
		_musicSource.Play();
	}

	/// <summary>
	/// Sets the music.
	/// </summary>
	/// <param name="actualScene">Actual scene.</param>
	public void SetMusic (SceneLevel actualScene) {
		_musicSource.clip = arrayMusic [(int)actualScene] as AudioClip;
	}

	/// <summary>
	/// Sets the music volume.
	/// </summary>
	/// <param name="volume">Volume.</param>
	public void SetMusicVolume(float volume){
		GetCameraSource ();
		_musicVolume = volume;
		_musicSource.volume = _musicVolume;
	}

	/// <summary>
	/// Stops the music.
	/// </summary>
	public void StopMusic(){
		_musicSource.Stop();
	}


	public void GetCameraSource(){
		_musicSource = Camera.main.GetComponent<AudioSource> ();
		_musicSource.volume = _musicVolume;
		_musicSource.loop = true;
	}
}