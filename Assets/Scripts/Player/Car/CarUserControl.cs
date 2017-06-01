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

		TwoAxisInputControl filteredDirectionH;
		TwoAxisInputControl filteredDirectionV;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();

			#if UNITY_IOS
			ICadeDeviceManager.Active = true;
			#endif

			//NEW
			filteredDirectionH = new TwoAxisInputControl();
			filteredDirectionH.StateThreshold = 0.5f;

			filteredDirectionV = new TwoAxisInputControl();
			filteredDirectionV.StateThreshold = 0.5f;
        }


        //private void FixedUpdate()
		private void Update()
        {

			/*var inputDevice = InputManager.ActiveDevice;
			filteredDirectionV.Filter (inputDevice.LeftStickRight, Time.deltaTime);
			filteredDirectionV.X

			filteredDirectionH.Right.WasPressed */

			// pass the input to the car!
			#if UNITY_IOS
			var inputDevice = InputManager.ActiveDevice;
			filteredDirectionH.Filter (inputDevice.Direction, Time.deltaTime);
			filteredDirectionV.Filter (inputDevice.LeftStickRight, Time.deltaTime);

			float h = 0.0f;
			float v = 0.0f;


			/*if (filteredDirection.Up.WasPressed || filteredDirection.Up.WasRepeated) {
				v = 1.0f;
			} else if (filteredDirection.Down.WasPressed || filteredDirection.Down.WasReleased) {
				v = -1.0f;
			}
			*/

			/*
			if (filteredDirection.Up.WasPressed || filteredDirection.Up.WasRepeated) {
			v = 1.0f;
			} else if (filteredDirection.Down.WasPressed || filteredDirection.Down.WasReleased) {
			v = -1.0f;
			}
			*/
			v = filteredDirectionH.Y;


			if (filteredDirectionH.Right.WasPressed || filteredDirectionH.Right.WasReleased) {
				h = 1.0f;
			} else if (filteredDirectionH.Left.WasPressed || filteredDirectionH.Left.WasReleased) {
				h = -1.0f;
			}

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
