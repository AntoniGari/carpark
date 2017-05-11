using System.Collections;
using UnityEngine;

public class RotateSkybox : MonoBehaviour {

	/// <summary>
	/// The skybox's scroll speed.
	/// </summary>
	private float scrollSpeed;

	/// <summary>
	/// The horizontal offset.
	/// </summary>
	private float horizontalOffset;

	// Use this for initialization
	void Start () {
		scrollSpeed = 2.0f;
		horizontalOffset = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		//Set Horizontal Offset
		horizontalOffset = horizontalOffset + (scrollSpeed * Time.deltaTime);

		//Animate Texture.
		RenderSettings.skybox.SetFloat ("_Rotation", horizontalOffset);
	}
}