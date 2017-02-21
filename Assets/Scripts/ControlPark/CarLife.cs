using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CarLife : MonoBehaviour {

	public float carLife;

	private CarUserControl carUserControl;
	private CarController m_Car;

	public void CheckLife() {
		if (carLife < 0.0f) {
			Debug.Log ("COTXE MORT");
		}
	}

	public void ReduceLife() {
		Debug.Log ("SPEED: " + carUserControl.GetCurrentSpeed());
		ReduceLife (1.0f);
	}

	public void ReduceLife(float reduction) {
		carLife -= reduction;
		CheckLife ();
	}
}
