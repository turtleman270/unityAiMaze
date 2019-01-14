using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RobotManager {

	static List<InsectRobot> robotList = new List<InsectRobot>();
	public static bool hasTimeLeft = true;

	public static int bestFitness=0;
	public static float bestLeftThreshold=0f;
	public static float bestRightThreshold=0f;
	public static float bestForwardThreshold=0f;



	public static int getBestFitness(){
		return bestFitness;
	}
	public static float getBestLeftThreshold(){
		return bestLeftThreshold;
	}
	public static float getBestRightThreshold(){
		return bestRightThreshold;
	}
	public static float getBestForwardThreshold(){
		return bestForwardThreshold;
	}

	public static void addRobot(){
		InsectRobot ir = new InsectRobot ();
		robotList.Add (ir);
	}

	public static void update(){
		if (hasTimeLeft) {
			for (int i = 0; i < robotList.Count; i++) {
				robotList [i].makeAMove ();
			}
		}
	}

	public static void sort(){
		robotList.Sort((x, y) => x.fitness.CompareTo(y.fitness));
		InsectRobot bestRobot = robotList [robotList.Count - 1];
		bestFitness = bestRobot.fitness;
		bestLeftThreshold = bestRobot.leftThreshold;
		bestRightThreshold = bestRobot.rightThreshold;
		bestForwardThreshold = bestRobot.forwardThreshold;
		for (int i = 0; i < robotList.Count; i++) {
			Debug.Log(robotList[i].getFitness());
		}
	}

	public static void outWithTheoldInWithTheNew(){
		for (int i = 0; i < robotList.Count; i++) {
			robotList [i].colisionDetector.isDead = false;
			if (i + (robotList.Count / 2) < robotList.Count) {
				//replace the shit with a deep copy of the good
				robotList[i].destroy();
				robotList [i] = new InsectRobot (robotList [i + (robotList.Count / 2)]);
			}
			robotList [i].augment();
		}
	}

	public static void moveBackToStart(){
		sort ();
		hasTimeLeft = false;
		for (int i = 0; i < robotList.Count; i++) {
			robotList [i].resetPosition();
		}
		outWithTheoldInWithTheNew ();
	}

	public static void restart(){
		hasTimeLeft = true;
	}

}
