using UnityEngine;
using System.Collections;

public class CarSuspension : MonoBehaviour {

	//#HEADER("SUSPENSION");
	public float springForce;
	public float damperForce;
	public float springConstant;
	public float damperConstant;
	public float restLength;

	private float previousLength;
	private float currentLength;
	private float springVelocity;

	public Rigidbody rb;
	private CarMovement car;

	// Use this for initialization
	void Start () {
		car = transform.parent.GetComponent<CarMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		springConstant = rb.mass * 15;

		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast (transform.position, -transform.up, out hit, restLength + car.wheelRadius)) {
			previousLength = currentLength;
			currentLength = restLength - (hit.distance - car.wheelRadius);
			springVelocity = (currentLength - previousLength) / Time.fixedDeltaTime;
			springForce = springConstant * currentLength;
			damperForce = damperConstant * springVelocity;

			rb.AddForceAtPosition (transform.up * (springForce + damperForce), transform.position);
		}
	}
}
