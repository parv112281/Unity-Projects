﻿using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour {

	// define the possible states through an enumeration
	public enum motionDirections {None, Horizontal, Vertical};
	
	// store the state
	public motionDirections motionState = motionDirections.Horizontal;

    public bool DoSpin = false;

	// motion parameters
	public float spinSpeed = 180.0f;
	public float motionMagnitude = 0.1f;

	// Update is called once per frame
	void Update () {

        if (DoSpin)
        {
            gameObject.transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }

		// do the appropriate motion based on the motionState
		switch(motionState) {
            case motionDirections.None:
                break;
			case motionDirections.Horizontal:
				// move up and down over time
				gameObject.transform.Translate(Vector3.right * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
				break;
			case motionDirections.Vertical:
				// move up and down over time
				gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMagnitude);
				break;
		}
	}
}
