using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDetector : MonoBehaviour {
	public bool isDead = false;
	void OnTriggerEnter(Collider other) {
		if (other.tag == "wall") {
			Debug.Log ("crash");
			isDead = true;
		}
	}
}
