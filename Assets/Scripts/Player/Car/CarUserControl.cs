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

		TwoAxisInputControl filteredDirection;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();

			#if UNITY_IOS
			ICadeDeviceManager.Active = true;
			#endif

			//NEW
			filteredDirection = new TwoAxisInputControl();
			filteredDirection.StateThreshold = 0.5f;
        }


        private void FixedUpdate()
        {
			float h = 0.0f;
			float v = 0.0f;



			// pass the input to the car!
			#if UNITY_IOS
			var inputDevice = InputManager.ActiveDevice;
			filteredDirection.Filter (inputDevice.Direction, Time.deltaTime);

			if (filteredDirection.Up.WasPressed) {
			v = 1.0f;
			} else if (filteredDirection.Down.WasPressed) {
			v = -1.0f;
			}

			coordenadesY.text = v.ToString ();
			coordenadesX.text = h.ToString ();
			#else
			h = CrossPlatformInputManager.GetAxis("Horizontal");
			v = CrossPlatformInputManager.GetAxis("Vertical");
			#endif


			#if !MOBILE_INPUT
			float handbrake = CrossPlatformInputManager.GetAxis("Jump");
			m_Car.Move(h, v, v, handbrake);
			Debug.Log("H: " + h + " - V: " + v);

			#else
			m_Car.Move(h, v, v, 1f);
			#endif


        }
    }
}
