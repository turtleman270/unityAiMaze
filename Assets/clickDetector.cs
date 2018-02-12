using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickDetector : MonoBehaviour {

	public MovementTracker tracker; 
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("click");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast (ray, out hit)) {
				if (tracker.isNotDead()) {
					if (hit.transform.tag == "increaseSpeed") {
						tracker.increaseSpeed ();
					} else if (hit.transform.tag == "decreaseSpeed") {
						tracker.decreaseSpeed ();
					} else if (hit.transform.tag == "increaseTurn") {
						tracker.increaseTurn ();
					} else if (hit.transform.tag == "decreaseTurn") {
						tracker.decreaseTurn ();
					}
				}
			}
		}
	}
}
