﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class CarDamage : MonoBehaviour {
	/// <summary>
	/// The car controller.
	/// </summary>
	private CarUserControl carControl;

	/// <summary>
	/// The car health.
	/// </summary>
	private float carHealth;

	/// <summary>
	/// The max car health.
	/// </summary>
	public float carHealthMax;

	/// <summary>
	/// The health text.
	/// </summary>
	private Text healthText;

	/// <summary>
	/// The parts per unit.
	/// </summary>
	private float partsPerUnit;

	/// <summary>
	/// The wasted image.
	/// </summary>
	private Image wastedImage;

	void Start () {
		carHealth = carHealthMax;
		partsPerUnit = 1 / carHealthMax;
	
		carControl = GameObject.FindGameObjectWithTag ("Player").GetComponent<CarUserControl> ();
		healthText = GameObject.FindGameObjectWithTag ("HealthText").GetComponent<Text>();
		wastedImage = GameObject.FindGameObjectWithTag ("WastedUI").GetComponent<Image>();

		ChangeHealthText();
	}

	/// <summary>
	/// Changes the health text.
	/// </summary>
	public void ChangeHealthText() {
		float aux = 1 - (partsPerUnit * carHealth);
		Color color = new Color (0 + aux, 1 - aux, 0, 1);
		healthText.color = color;

		if (carHealth >= 0) {
			healthText.text = carHealth.ToString();
		}
	}

	/// <summary>
	/// Checks the life.
	/// </summary>
	public void CheckLife() {
		if (carHealth <= 0.0f) {
			carControl.Brake ();
			carControl.enabled = false;
			wastedImage.color = Color.white;
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
		if (carHealth < 0)
			carHealth = 0;
		ChangeHealthText();
		CheckLife ();
	}
}
