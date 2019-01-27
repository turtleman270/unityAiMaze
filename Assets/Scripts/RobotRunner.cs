using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRunner : MonoBehaviour {
	//note that is script needs to be attached to some object
	void Update () {
		//this is where all my robots will look and make their moves
		RobotManager.update();
	}
}
