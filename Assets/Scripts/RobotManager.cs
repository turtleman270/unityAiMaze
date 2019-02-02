using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RobotManager {

	public static List<InsectRobot> robotList = new List<InsectRobot>();
	public static bool hasTimeLeft = true;

    public static float totalBugs = 0f;


	public static void addRobot(){
		InsectRobot ir = new InsectRobot ();
		robotList.Add (ir);
        totalBugs = robotList.Count;
        Debug.Log(totalBugs);
	}

	public static void update(){
		if (hasTimeLeft) {
			for (int i = 0; i < robotList.Count; i++) {
				robotList [i].makeAMove ();
			}
		}
	}

	public static void sort(){
		robotList.Sort((x, y) => y.fitness.CompareTo(x.fitness));
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
		hasTimeLeft = false;
		for (int i = 0; i < robotList.Count; i++) {
			robotList [i].resetPosition();
            robotList[i].colisionDetector.isDead = false;
        }
	}

    public static void deleteHalf(){
        for(int i = (robotList.Count+1)/2; i<robotList.Count; i++){
            robotList[i].destroy();
        }
        robotList.RemoveRange((robotList.Count+1)/2,robotList.Count/2);
        totalBugs = robotList.Count;
    }

    public static void cloneAll(){
        int numRobots = robotList.Count;
        for(int i = 0; i<numRobots; i++){
            InsectRobot ir = new InsectRobot(robotList[i]);
            robotList.Add(ir);
            totalBugs = robotList.Count;
            Debug.Log("2355255378325377432073204532430");
        }
    }


}
