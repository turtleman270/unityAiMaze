using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeInfo : MonoBehaviour {

	public string mazeName{ get; set; }

	public Vector3 robotStartPos { get; set; }
	public Quaternion robotStartRot { get; set; }

	public Vector3 cameraPos { get; set; }
	public Quaternion cameraRot { get; set; }

	public MazeInfo(string mazeName, Vector3 robotStartPos, Quaternion robotStartRot,
		Vector3 cameraPos, Quaternion cameraRot){
		this.mazeName = mazeName;
		this.robotStartPos = robotStartPos;
		this.robotStartRot = robotStartRot;
		this.cameraPos = cameraPos;
		this.cameraRot = cameraRot;
	}
}
