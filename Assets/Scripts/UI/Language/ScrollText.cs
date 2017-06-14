using UnityEngine;
using System.Collections;

public class ScrollText : MonoBehaviour {
	/// <summary>
	/// The start position.
	/// </summary>
	private float startPosition;

	/// <summary>
	/// The max Height that text can scroll.
	/// </summary>
	public float maxHeight;

	/// <summary>
	/// The scroll speed.
	/// </summary>
	public float speed;

	// Use this for initialization
	void Start () {
		startPosition = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);

		if (transform.position.y > maxHeight)
			transform.position = new Vector3 (transform.position.x, startPosition, transform.position.z);
	}

	void OnDisable() {
		transform.position = new Vector3 (transform.position.x, startPosition, transform.position.z);
	}
}
