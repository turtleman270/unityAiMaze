using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickDetector : MonoBehaviour {

	public float startTime;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("click");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast (ray, out hit)) {
            
                if (hit.transform.tag == "addRobots"){
                    RobotManager.hasTimeLeft = false;
                    for (int i = 0; i < configs.addRobotsAmount; i++){
                        RobotManager.addRobot();
                    }
                }
                if (hit.transform.tag == "sortRobots"){
                    RobotManager.hasTimeLeft = false;
                    RobotManager.sort();
                }
                if (hit.transform.tag == "deleteRobots"){
                    RobotManager.hasTimeLeft = false;
                    RobotManager.deleteHalf();
                }
                if (hit.transform.tag == "replaceRobots"){
                    RobotManager.hasTimeLeft = false;
                    RobotManager.clone();
                }
                if (hit.transform.tag == "augmentRobots"){
                    RobotManager.hasTimeLeft = false;
                    for (int i = 0;  i<RobotManager.robotList.Count; i++){
                        RobotManager.robotList[i].augment();
                    }
                }
                if (hit.transform.tag == "repositionRobots"){
                    RobotManager.hasTimeLeft = false;
                    RobotManager.moveBackToStart();
                }
                if (hit.transform.tag == "runRobots"){
                    startTime = Time.time;
                    RobotManager.hasTimeLeft = true;
                }

            }
        }


		if ((Time.time - startTime) > configs.maxRunTime) {
			RobotManager.hasTimeLeft = false;
		}
	}
}
