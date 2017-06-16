using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class ControlParkZone : MonoBehaviour {
	/// <summary>
	/// The time to check when the car is parked.
	/// </summary>
	public float checkingTime;

	/// <summary>
	/// The time to check when the car is parked.
	/// </summary>
	public float unfillingTime;

	/// <summary>
	/// The parking logo.
	/// </summary>
	public Image parkingLogo;

	/// <summary>
	/// The win main menu window.
	/// </summary>
	public GameObject mainMenuWin;

	/// <summary>
	/// The car damage script.
	/// </summary>
	private CarDamage carDamage;

	/// <summary>
	/// The car controller.
	/// </summary>
	private CarUserControl carControl;

	/// <summary>
	/// The number of wheels.
	/// </summary>
	private int _wheels;

	/// <summary>
	/// Filles the park logo.
	/// </summary>
	private IEnumerator _fillingLogo;

	/// <summary>
	/// The park timer.
	/// </summary>
	private IEnumerator _parkTimer;

	/// <summary>
	/// Filles the park logo.
	/// </summary>
	private IEnumerator _unfillingLogo;

	// Use this for initialization
	void Start () {
		//Public
		checkingTime = 6.0f;
		unfillingTime = 1.0f;

		//Private
		_wheels = 0;
		_parkTimer = ControlParkTime (checkingTime);
		_fillingLogo = FillingLogo (checkingTime);
		_unfillingLogo = null;
		carControl = GameObject.FindGameObjectWithTag ("Player").GetComponent<CarUserControl> ();
		carDamage = GameObject.Find("ColliderBottom").GetComponent<CarDamage>();
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

				if (_unfillingLogo != null)
					StopCoroutine (_unfillingLogo);
				_unfillingLogo = UnfillingLogo(unfillingTime);

				StartCoroutine (_fillingLogo);
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
				_parkTimer = ControlParkTime (checkingTime);

				StopCoroutine (_fillingLogo);
				_fillingLogo = FillingLogo (checkingTime);

				StartCoroutine (_unfillingLogo);
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
		carControl.Brake ();
		carControl.enabled = false;

		if (carDamage.carIsAlive())
			mainMenuWin.SetActive (true);
	}

	/// <summary>
	/// Fillings the logo.
	/// </summary>
	/// <returns>The logo.</returns>
	/// <param name="waitTime">Wait time.</param>
	private IEnumerator FillingLogo(float waitTime){
		float fillingTime = 0.0f;
		parkingLogo.fillAmount = 0;

		while (fillingTime <= waitTime) {
			fillingTime += Time.deltaTime;
			parkingLogo.fillAmount = fillingTime/waitTime;

			yield return null;
		}
	}

	/// <summary>
	/// Unfillings the logo.
	/// </summary>
	/// <returns>The logo.</returns>
	/// <param name="waitTime">Wait time.</param>
	private IEnumerator UnfillingLogo(float waitTime){
		float fillingTime = parkingLogo.fillAmount * waitTime;

		while (fillingTime < waitTime) {
			fillingTime -= Time.deltaTime;
			parkingLogo.fillAmount = fillingTime/waitTime;

			yield return null;
		}
	}
}
