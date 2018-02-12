using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayData : MonoBehaviour {

	public MovementTracker tracker; 

	void OnGUI() {
		GUI.Label (new Rect(10, 10, 90, 40), ("Speed: "+tracker.getSpeed()));
		GUI.Label (new Rect (10, 50, 90, 40), ("Turn: " + tracker.getTurnMultiplyer ()));
	}
}
