using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDamage : MonoBehaviour {
	/// <summary>
	/// The car health.
	/// </summary>
	public float carHealth;

	//private CarUserControl carUserControl;
	//private CarController m_Car;

	/// <summary>
	/// Checks the life.
	/// </summary>
	public void CheckLife() {
		if (carHealth <= 0.0f) {
			Debug.Log ("COTXE MORT");
		}
	}

	/// <summary>
	/// Kills the car.
	/// </summary>
	public void KillCar() {
		carHealth = 0;
	}

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col) {
		switch (col.gameObject.tag) {
		case "Environment":
		case "Wall":
			Debug.Log ("ACCIDENT");
			ReduceLife (50.0f);
			break;
		} 
	}

	/// <summary>
	/// Reduces the life considering the actual speed.
	/// </summary>
	public void ReduceLife() {
		//ERROR
		//Debug.Log ("SPEED: " + carUserControl.GetCurrentSpeed());
		ReduceLife (1.0f);
	}

	/// <summary>
	/// Reduces the life.
	/// </summary>
	/// <param name="reduction">Reduction.</param>
	public void ReduceLife(float reduction) {
		carHealth -= reduction;
		CheckLife ();
	}
}
