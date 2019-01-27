using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayData : MonoBehaviour {

	void OnGUI() {

		GUI.Label (new Rect(10, 10, 200, 40), ("Fitness: "+RobotManager.getBestFitness()));
		GUI.Label (new Rect(10, 30, 200, 40), ("L Thresh: "+RobotManager.getBestLeftThreshold()));
		GUI.Label (new Rect(10, 50, 200, 40), ("R Thresh: "+RobotManager.getBestRightThreshold()));
		GUI.Label (new Rect(10, 70, 200, 40), ("F Thresh: "+RobotManager.getBestForwardThreshold()));

	}
}
