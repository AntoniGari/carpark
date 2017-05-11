using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using InControl;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use


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

			var inputDevice = InputManager.ActiveDevice;

			// pass the input to the car!
			#if UNITY_IOS
				var controlX = inputDevice.LeftStickX;
				float h = controlX.Value;
				var controlY = inputDevice.LeftStickY;
				float v = controlY.Value;
			#else
				float h = CrossPlatformInputManager.GetAxis("Horizontal");
				float v = CrossPlatformInputManager.GetAxis("Vertical");
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
