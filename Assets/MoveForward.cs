using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

	public MovementTracker tracker; 

	void Update () {
		if (tracker.isNotDead()) {
			transform.position += transform.forward*tracker.getSpeed();
			transform.Rotate (0, tracker.getDirection(), 0);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "wall") {
			tracker.die ();
		}
	}
}
