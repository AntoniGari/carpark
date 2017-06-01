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
		private ControllerHelper test;

		public Text coordenadesX;
		public Text coordenadesY;

		//NEW
		TwoAxisInputControl filteredDirection;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
			//test = GetComponent<ControllerHelper> ();

			#if UNITY_IOS
			ICadeDeviceManager.Active = true;
			#endif

			//NEW
			filteredDirection = new TwoAxisInputControl();
			filteredDirection.StateThreshold = 0.5f;
        }


        private void FixedUpdate()
        {
			//GameManager.Instance.controllerManager.


			float h;
			float v;

			// pass the input to the car!
			#if UNITY_IOS
				/*var inputDevice = InputManager.ActiveDevice;
				var controlX = inputDevice.LeftStickX;
				float h = controlX.Value;
				var controlY = inputDevice.LeftStickY;
				float v = controlY.Value;
				//coordenadesX.text = string.Format( "{0} {1}", "Left Stick X = ", test.GetLeftStickX());
				//coordenadesY.text = string.Format( "{0} {1}", "Left Stick Y = ", test.GetLeftStickY());
				m_Car.Move(h, v, v, 0f);
				*/
			var inputDevice = InputManager.ActiveDevice;
			filteredDirection.Filter (inputDevice.Direction, Time.deltaTime);

			if (filteredDirection.Up.WasPressed) {
			v = 1.0f;
			} else if (filteredDirection.Down.WasPressed) {
			v = -1.0f;
			}
			#else
			h = CrossPlatformInputManager.GetAxis("Horizontal");
			v = CrossPlatformInputManager.GetAxis("Vertical");
			#endif


			#if !MOBILE_INPUT
			float handbrake = CrossPlatformInputManager.GetAxis("Jump");
			m_Car.Move(h, v, v, handbrake);
			#else
			m_Car.Move(h, v, v, 0f);
			#endif


        }
    }
}
