using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using InControl;
using UnityEngine.UI;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

		/// <summary>
		/// The filtered direction.
		/// </summary>
		TwoAxisInputControl filteredDirection;

		/// <summary>
		/// The filtered direction.
		/// </summary>
		TwoAxisInputControl filteredBreak;

        private void Awake() {
            // get the car controller
            m_Car = GetComponent<CarController>();

			#if UNITY_IOS
			ICadeDeviceManager.Active = true;
			#endif

			filteredDirection = new TwoAxisInputControl();
			filteredDirection.StateThreshold = 0.5f;
        }


        //private void FixedUpdate()
		private void Update() {

			// pass the input to the car!
			#if UNITY_IOS
			var inputDevice = InputManager.ActiveDevice;
			filteredDirection.Filter (inputDevice.Direction, Time.deltaTime);

			float h = filteredDirection.X;
			float v = filteredDirection.Y;
			#else
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			float v = CrossPlatformInputManager.GetAxis("Vertical");
			#endif


			#if !MOBILE_INPUT
			float handbrake = CrossPlatformInputManager.GetAxis("Jump");
			m_Car.Move(h, v, v, handbrake);
			#else
			var inputBreak = InputManager.ActiveDevice;
			filteredBreak.Filter (inputBreak.LeftTrigger, Time.deltaTime);

			float handbrake = filteredBreak.IsPressed ? 1.0f:0.0f;
			m_Car.Move(h, v, v, handbrake);
			#endif


        }

		/// <summary>
		/// Start a Car desacceleration.
		/// </summary>
		public void Brake () {
			m_Car.Move(0, 0, 0, 1.0f);
		}
    }
}
