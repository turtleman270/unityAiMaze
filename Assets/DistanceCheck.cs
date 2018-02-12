using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCheck : MonoBehaviour {
	
	// Update is called once per frame

	float l = 0f;
	float lf = 0f;
	float f = 0f;
	float rf = 0f;
	float r = 0f;

	public MovementTracker tracker;

	void Update () {
		RaycastHit hit;

		if (Physics.Raycast(transform.position, -transform.right,out hit)) {
			l = hit.distance;
		}
		if (Physics.Raycast(transform.position, transform.forward-transform.right,out hit)) {
			lf = hit.distance;
		}
		if (Physics.Raycast(transform.position, transform.forward,out hit)) {
			f = hit.distance;
		}
		if (Physics.Raycast(transform.position, transform.forward+transform.right,out hit)) {
			rf = hit.distance;
		}
		if (Physics.Raycast(transform.position, transform.right,out hit)) {
			r = hit.distance;
		}

		float magicNumber = fancyAlgorithm (l, lf, f, rf, r);

		if (magicNumber < 0) {
			tracker.turnLeft ();
		}
		else if (magicNumber > 0) {
			tracker.turnRight ();
		}
		else {
			tracker.goStraight ();
		}
	}

	float fancyAlgorithm(float left, float leftUp, float up, float rightUp, float right){
		// negative left
		// positive right
		if (right < 1.5) {
			return -1;
		}
		if (left < 1.5) {
			return 1;
		}
		return -left *leftUp + right *rightUp;
	}

}
