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


        //private void FixedUpdate()
		private void Update()
        {

			// pass the input to the car!
			#if UNITY_IOS
			var inputDevice = InputManager.ActiveDevice;
			filteredDirection.Filter (inputDevice.Direction, Time.deltaTime);

			float h = filteredDirection.Y;
			float v = filteredDirection.X;

			coordenadesY.text = v.ToString ();
			coordenadesX.text = h.ToString ();
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
