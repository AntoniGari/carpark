using UnityEngine;
using System.Collections;

/// <summary>
/// Component manager.
/// </summary>
public class ComponentManager : ScriptableObject {

	/// <summary>
	/// Camera components.
	/// </summary>
	public class CameraComponents {
		/// <summary>
		/// The audio source.
		/// </summary>
		public AudioSource audioSource;

		/// <summary>
		/// Initializes a new instance of the <see cref="ComponentManager+CameraComponents"/> class.
		/// </summary>
		public CameraComponents(){
			audioSource = Camera.main.GetComponent<AudioSource> ();
		}

		/// <summary>
		/// Gets the camera audio source.
		/// </summary>
		/// <returns>The camera audio source.</returns>
		public AudioSource GetCameraAudioSource(){
			return audioSource;
		}
	}

	/// <summary>
	/// Player components.
	/// </summary>
	public class PlayerComponents {
		/// <summary>
		/// The transform.
		/// </summary>
		public Transform transform;

		/// <summary>
		/// Initializes a new instance of the <see cref="ComponentManager+PlayerComponents"/> class.
		/// </summary>
		public PlayerComponents(){
			//transform = ;
		}

		/// <summary>
		/// Gets the player transform.
		/// </summary>
		/// <returns>The player transform.</returns>
		public Transform GetPlayerTransform(){
			return transform;
		}
	}

	/// <summary>
	/// All the components.
	/// </summary>
	public static CameraComponents camera;
	public static PlayerComponents player;

	#region Singleton
	/// <summary>
	/// Static instance.
	/// </summary>
	private static ComponentManager instance = null;

	/// <summary>
	/// Get the singleton instance
	/// </summary>
	public static ComponentManager Instance {
		get {
			if(instance == null) instance = CreateInstance<ComponentManager> ();
			return instance;
		}
	}
	#endregion

	/// <summary>
	/// Initializes a new instance of the <see cref="ComponentManager"/> class.
	/// </summary>
	private ComponentManager(){
		//CAMERA COMPONENTS
		camera = new CameraComponents ();

		//PLAYER COMPONENTS
		player = new PlayerComponents();
	}
}
