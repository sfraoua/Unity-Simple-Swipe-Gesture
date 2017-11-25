namespace Liya.Gestures
{
	
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class IsometricSwipeGesture : MonoBehaviour
	{

		private bool tap, swipeUpLeft, swipeUpRight, swipeDownRight, swipeDownLeft;
		private bool isDraging = false;

		private Vector2 startTouch, swipeDelta;

		public Vector2 SwipeDelta { get { return swipeDelta; } }

		public bool Tap { get { return tap; } }

		public bool SwipeUpLeft { get { return swipeUpLeft; } }

		public bool SwipeUpRight { get { return swipeUpRight; } }

		public bool SwipeDownRight { get { return swipeDownRight; } }

		public bool SwipeDownLeft { get { return swipeDownLeft; } }

		// Use this for initialization
		void Start ()
		{
			
		}
		
		// Update is called once per frame
		void Update ()
		{
			tap = swipeUpLeft = swipeUpRight = swipeDownRight = swipeDownLeft = false;

			#region Standlone Iputs
			if (Input.GetMouseButtonDown (0)) {
				tap = true;
				isDraging = true;
				startTouch = Input.mousePosition;
			} else if (Input.GetMouseButtonUp (0)) {
				isDraging = false;
				Reset ();
			}
			#endregion

			#region Mobile Iputs
			if (Input.touches.Length > 0) {
				if (Input.touches [0].phase == TouchPhase.Began) {
					tap = true;
					isDraging = true;
					startTouch = Input.touches [0].position;
				} else if (Input.touches [0].phase == TouchPhase.Ended || Input.touches [0].phase == TouchPhase.Canceled) {
					isDraging = false;
					Reset ();
				}
			}
			#endregion

			//Calculate the distance
			swipeDelta = Vector2.zero;
			if (isDraging) {
				if (Input.touches.Length > 0)
					swipeDelta = Input.touches [0].position - startTouch;
				else if (Input.GetMouseButton (0))
					swipeDelta = (Vector2)Input.mousePosition - startTouch;
			}

			//did we cross the deadzone ?
			if (swipeDelta.magnitude > 50) {
				float x = swipeDelta.x;
				float y = swipeDelta.y;

				{
					//left or right
					if (x > 0 && y > 0) {
						swipeUpRight = true;
						print ("swipe Up Right");
					} else if (x < 0 && y > 0) {
						swipeUpLeft = true; 
						print ("swipe Up left");
					} else if (x > 0 && y < 0) {
						swipeDownRight = true;
						print ("swipe down right");
					} else {                
						swipeDownLeft = true;
						print ("swipe down left");
					}

					Reset ();
				}
			}
		}

		void Reset ()
		{
			startTouch = swipeDelta = Vector2.zero;
			isDraging = false;
		}
	}

}


