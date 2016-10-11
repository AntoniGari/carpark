using UnityEngine;
using System.Collections;
using EnumAudio;

/// <summary>
/// Audio manager.
/// </summary>
public class AudioManager : MonoBehaviour {

	/// <summary>
	/// The instance.
	/// </summary>
	private static AudioManager instance;

	/// <summary>
	/// The array FX.
	/// </summary>
	public Object[] arrayFx;

	/// <summary>
	/// The current FX.
	/// </summary>
	private FxClip _currentFx;

	/// <summary>
	/// The fx source.
	/// </summary>
	private static AudioSource _fxSource;

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static AudioManager Instance {
		get {
			if(instance == null) {
				GameObject go = new GameObject ("Audio Manager");
				instance = go.AddComponent<AudioManager> ();
				_fxSource = go.AddComponent<AudioSource> ();
				_fxSource.playOnAwake = false;
				_fxSource.loop = false;
				_fxSource.volume = 1;
				DontDestroyOnLoad(go);
			}	
			return instance;
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="AudioManager"/> class.
	/// </summary>
	private AudioManager(){
		_currentFx = FxClip.NO_FX;
	}

	/// <summary>
	/// Gets the FX volume.
	/// </summary>
	/// <returns>The FX volume.</returns>
	public float GetFXVolume(){
		return _fxSource.volume;
	}

	/// <summary>
	/// Determines whether this instance is playing.
	/// </summary>
	/// <returns><c>true</c> if this instance is playing; otherwise, <c>false</c>.</returns>
	public bool IsPlaying(){
		return _fxSource.isPlaying;
	}

	/// <summary>
	/// Loads the audio files.
	/// </summary>
	public void LoadAudioFiles(){
		arrayFx =  Resources.LoadAll("Audio", typeof(AudioClip));
	}

	/// <summary>
	/// Plaies the FX.
	/// </summary>
	public void PlayFX () {
		_fxSource.PlayOneShot(arrayFx[(int) _currentFx] as AudioClip);
	}

	/// <summary>
	/// Plaies the FX.
	/// </summary>
	/// <param name="fx">Fx.</param>
	public void PlayFX (FxClip fx) {
		_currentFx = fx;
		PlayFX ();
	}

	/// <summary>
	/// Removes the current FX.
	/// </summary>
	public void RemoveFX(){
		_currentFx = FxClip.NO_FX;
	}

	/// <summary>
	/// Sets the FX.
	/// </summary>
	/// <param name="fx">Fx.</param>
	public void SetFX(FxClip fx){
		_currentFx = fx;
	}

	/// <summary>
	/// Sets the FX volume.
	/// </summary>
	/// <param name="volume">Volume.</param>
	public void SetFXVolume(float volume){
		_fxSource.volume = volume;
	}

	/// <summary>
	/// Sets the FX volume max.
	/// </summary>
	public void SetFXVolumeMax(){
		_fxSource.volume = 1.0f;
	}

	/// <summary>
	/// Sets the FX volume minimum.
	/// </summary>
	public void SetFXVolumeMin(){
		_fxSource.volume = 0.0f;
	}

	/// <summary>
	/// Stops the FX.
	/// </summary>
	public void StopFX(){
		_fxSource.Stop();
	}
}