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

		public Text coordenadesX;
		public Text coordenadesY;

		public TestInputManager test; 

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();

			#if UNITY_IOS
			ICadeDeviceManager.Active = true;
			#endif
        }

		void Start() {
			
		}

        private void FixedUpdate()
        {
			//GameManager.Instance.controllerManager.
			//TestInputManager.

			// pass the input to the car!
			#if UNITY_IOS
				var inputDevice = InputManager.ActiveDevice;
				var controlX = inputDevice.LeftStickX;
				float h = controlX.Value;
				var controlY = inputDevice.LeftStickY;
				float v = controlY.Value;
				coordenadesX.text = string.Format( "{0} {1}", "Left Stick X", test.GetLeftStickX());
				coordenadesY.text = string.Format( "{0} {1}", "Left Stick Y", test.GetLeftStickY());
				m_Car.Move(h, v, v, 0f);
			#else
				float h = CrossPlatformInputManager.GetAxis("Horizontal");
				float v = CrossPlatformInputManager.GetAxis("Vertical");
				coordenadesX.text = string.Format( "{0} {1}", "Left Stick X = ", test.GetLeftStickX());
				coordenadesY.text = string.Format( "{0} {1}", "Left Stick Y = ", test.GetLeftStickY());
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
