using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {
	public GameObject camera;
	// Use this for initialization
	void Start () {
		camera.transform.position = configs.cameraPos;
		camera.transform.rotation = configs.cameraRot;
	}
}
