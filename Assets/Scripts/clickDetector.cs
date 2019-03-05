using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickDetector : MonoBehaviour {

	public float startTime;

    void add(){
		RobotManager.hasTimeLeft = false;
		for (int i = 0; i < configs.addRobotsAmount; i++) {
			RobotManager.addRobot();
		}
	}
	void sort(){
		RobotManager.hasTimeLeft = false;
		RobotManager.sort();
	}
	void delete(){
		RobotManager.hasTimeLeft = false;
		RobotManager.deleteHalf();
	}
	void replace(){
		RobotManager.hasTimeLeft = false;
		RobotManager.cloneAll();
	}
	void augment(){
		RobotManager.hasTimeLeft = false;
		for (int i = 0; i < RobotManager.robotList.Count; i++) {
			RobotManager.robotList[i].augment();
		}
	}
	void reposition(){
		RobotManager.hasTimeLeft = false;
		RobotManager.moveBackToStart();
	}
	void run(){
		startTime = Time.time;
		RobotManager.hasTimeLeft = true;
		RobotManager.increaseGeneration();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("click");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast (ray, out hit)) {
				switch (hit.transform.tag) {
					case "addRobots":
						add();
						break;
					case "sortRobots":
						sort();
						break;
					case "deleteRobots":
						delete();
						break;
					case "replaceRobots":
						replace();
						break;
					case "augmentRobots":
						augment();
						break;
					case "repositionRobots":
						reposition();
						break;
					case "runRobots":
						run();
						break;
				}
            }
        }
		if (Input.GetKeyDown(configs.addRobotsKey)) {
			add();
		}
		if (Input.GetKeyDown(configs.sortKey)) {
			sort();
		}
		if (Input.GetKeyDown(configs.deleteHalfKey)) {
			delete();
		}
		if (Input.GetKeyDown(configs.replaceKey)) {
			replace();
		}
		if (Input.GetKeyDown(configs.augmentKey)) {
			augment();
		}
		if (Input.GetKeyDown(configs.repositionKey)) {
			reposition();
		}
		if (Input.GetKeyDown(configs.resetAndRunKey)) {
			run();
		}


		if ((Time.time - startTime) > configs.maxRunTime) {
			RobotManager.hasTimeLeft = false;
		}
	}
}
