using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllGuiStuff : MonoBehaviour {

	public float startTime;

	void OnGUI() {
        if (configs.displayDataOnScreen){

			//left side info
            for (int i = 0; i < RobotManager.totalBugs; i++){
                GUI.Label(new Rect(10, 10 + (i * 15), 200, 40), ("Robot " + i + " " + RobotManager.robotList[i].fitness));
            }


			//generation info
			GUI.Label(new Rect(Screen.width/2, 15,150,40),("Generation "+RobotManager.generation));


			//Bottom buttons
			if (GUI.Button(new Rect(50, Screen.height - 50, 75, 40), "Add Robots\n(a)")) {
				add();
			}
			if (GUI.Button(new Rect(150, Screen.height - 50, 75, 40), "Sort\n(s)")) {
				sort();
			}
			if (GUI.Button(new Rect(250, Screen.height - 50, 75, 40), "Delete Half\n(d)")) {
				delete();
			}
			if (GUI.Button(new Rect(350, Screen.height - 50, 75, 40), "Replace\n(f)")) {
				replace();
			}
			if (GUI.Button(new Rect(450, Screen.height - 50, 75, 40), "Augment\n(j)")) {
				augment();
			}
			if (GUI.Button(new Rect(550, Screen.height - 50, 75, 40), "Reposition\n(k)")) {
				reposition();
			}
			if (GUI.Button(new Rect(650, Screen.height - 50, 75, 40), "Run\n(l)")) {
				run();
			}

		}
	}




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
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("click");
			/*
			//this is what I normall use to detect clicks on objects
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast (ray, out hit)) {
				switch (hit.transform.tag) {
					case "addRobots":
						add();
						break;
				}
            }
			*/
		}

		//any of the game button keys
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

		//any of the maze number keys
		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			configs.updateMazeNum(0);
		}
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			configs.updateMazeNum(1);
		}

		if ((Time.time - startTime) > configs.maxRunTime) {
			RobotManager.hasTimeLeft = false;
		}
	}
}
