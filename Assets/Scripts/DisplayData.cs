using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayData : MonoBehaviour {

	void OnGUI() {
        if (configs.displayDataOnScreen){

            for (int i = 0; i < RobotManager.totalBugs; i++){
                GUI.Label(new Rect(10, 10 + (i * 15), 200, 40), ("Robot " + i + " " + RobotManager.robotList[i].fitness));
            }
			GUI.Label(new Rect(400, 15,150,40),("Generation "+RobotManager.generation));
        }
    }
}
