using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car {
	[RequireComponent(typeof (CarController))]
	public class CarUserControl : MonoBehaviour {
		private CarController m_Car; // the car controller we want to use
		private ControllerManager control;

		float h;
		float v;
		float handbrake;

		private void Awake() {
			// get the car controller
			m_Car = GetComponent<CarController>();
			control = ControllerManager.Instance;
		}


		private void FixedUpdate() {
			// pass the input to the car!
			if (control.IsPressed ("Forward") || control.IsPressed ("Back")) {
				h = control.RawRotation ();
				v = control.RawAcceleration ();

				#if !MOBILE_INPUT
				//handbrake = control.LeftTrigger.RawValue;
				m_Car.Move(h, v, v, handbrake);
				#else
				m_Car.Move(h, v, v, 0f);
				#endif
			}
		}

		public float GetCurrentSpeed() {
			return m_Car.CurrentSpeed;
		}
	}
}