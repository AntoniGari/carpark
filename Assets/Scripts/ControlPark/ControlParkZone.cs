using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlParkZone : MonoBehaviour {
	/// <summary>
	/// The time to check when the car is parked.
	/// </summary>
	public float checkingTime;

	/// <summary>
	/// The number of wheels.
	/// </summary>
	private int _wheels;

	/// <summary>
	/// The park timer.
	/// </summary>
	private IEnumerator _parkTimer;

	// Use this for initialization
	void Start () {
		_wheels = 0;
		checkingTime = 5.0f;
		_parkTimer = ControlParkTime (checkingTime); 
	}

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag("Wheel")) {
			++_wheels;
			if (_wheels == 4) {
				StartCoroutine (_parkTimer);
			}
		}
	}

	/// <summary>
	/// Raises the trigger exit event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerExit(Collider col) {
		if (col.gameObject.CompareTag("Wheel")) {
			if (_wheels == 4) {
				StopCoroutine (_parkTimer);
			}
			--_wheels;
		}
	}

	/// <summary>
	/// Controls the park time.
	/// </summary>
	/// <returns>The park time.</returns>
	/// <param name="waitTime">Wait time.</param>
	private IEnumerator ControlParkTime(float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Debug.Log ("Aparcat!");
	}
}
