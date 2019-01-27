using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickDetector : MonoBehaviour {

	public MovementTracker tracker; 
	public GameObject prefabBug;
	public GameObject startPosition;
	public float startTime;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("click");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast (ray, out hit)) {

				//left buttons
				if (hit.transform.tag == "one") {
					//make the bug or whatever
					startTime = Time.time;
					RobotManager.hasTimeLeft = true;
					for (int i = 0; i < configs.addRobotsAmount; i++) {
						RobotManager.addRobot();
					}
				}
				if (hit.transform.tag == "two") {
					RobotManager.moveBackToStart ();
				}

				if (hit.transform.tag == "three") {
					startTime = Time.time;
					RobotManager.hasTimeLeft = true;
				}
			}
		}


		if ((Time.time - startTime) > 20) {
			RobotManager.hasTimeLeft = false;
		}
	}
}
