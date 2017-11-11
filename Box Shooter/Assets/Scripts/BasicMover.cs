using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMover : MonoBehaviour {
    public float SpinSpeed = 180.0f;
    public float MotionMagnitude = 0.1f;

    public bool DoSpin = true;
    public bool DoMotion = false;

	// Update is called once per frame
	void Update () {
        if (DoSpin)
        {
            // rotate around the y-axis
            gameObject.transform.Rotate(Vector3.up * SpinSpeed * Time.deltaTime);
        }

        if (DoMotion)
        {
            // move up and down over time
            gameObject.transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * MotionMagnitude);
        }
	}
}
