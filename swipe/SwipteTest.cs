using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipteTest : MonoBehaviour
{
    public Swipe swipeControls;
    public Transform player;
    private Vector3 desiredPosition;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (swipeControls.SwipeLeft)
            desiredPosition += Vector3.left;
        else if (swipeControls.SwipeRight)
            desiredPosition += Vector3.right;
        else if (swipeControls.SwipeUp)
            desiredPosition += Vector3.forward;
        else if (swipeControls.SwipeDown)
            desiredPosition += Vector3.back;


        player.transform.position = Vector3.MoveTowards(player.transform.position, desiredPosition, 3f * Time.deltaTime);


    }
}