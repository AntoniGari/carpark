using UnityEngine;
using System.Collections;

/// <summary>
/// Component manager.
/// </summary>
public class ComponentManager : MonoBehaviour {

	/// <summary>
	/// The instance.
	/// </summary>
	private static ComponentManager instance;

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
	public new static CameraComponents camera;
	public static PlayerComponents player;

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static ComponentManager Instance {
		get {
			if(instance == null) {
				GameObject go = new GameObject ("Component Manager");
				instance = go.AddComponent<ComponentManager> ();
				//DontDestroyOnLoad(go);
			}	
			return instance;
		}
	}

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
