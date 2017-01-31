using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlParkZone : MonoBehaviour {

	int wheels;

	private IEnumerator parkTimer;

	// Use this for initialization
	void Start () {
		wheels = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag("Wheel")) {
			++wheels;
			//Debug.Log ("Wheel Enter: " + wheels);
			if (wheels == 4)
				Debug.Log ("Comença Coroutina");
				parkTimer = ControlParkTime (5.0f); 
				StartCoroutine (parkTimer);
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.gameObject.CompareTag("Wheel")) {
			//Debug.Log ("Wheel Exit: " + wheels);
			if (wheels == 4) {
				Debug.Log ("Para Coroutina");
				StopCoroutine (parkTimer);
			}
			--wheels;
		}
	}

	private IEnumerator ControlParkTime(float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Debug.Log ("Aparcat!");
	}
}
