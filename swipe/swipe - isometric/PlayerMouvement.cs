using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liya.Gestures;

public class PlayerMouvement : MonoBehaviour
{
	public IsometricSwipeGesture swipeControls;
	public Transform player;
	private Vector3 desiredPosition;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
		if (swipeControls.SwipeUpLeft)
			desiredPosition += (Vector3.left + Vector3.forward);
		else if (swipeControls.SwipeUpRight)
			desiredPosition += (Vector3.right + Vector3.forward);
		else if (swipeControls.SwipeDownRight)
			desiredPosition += (Vector3.right + Vector3.back);
		else if (swipeControls.SwipeDownLeft)
			desiredPosition += (Vector3.left + Vector3.back);


		player.transform.position = Vector3.MoveTowards (player.transform.position, desiredPosition, 3f * Time.deltaTime);

	}
}
