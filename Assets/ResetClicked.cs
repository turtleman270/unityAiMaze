using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetClicked : MonoBehaviour {

	public MovementTracker tracker; 


	void OnMouseDown(){
		tracker.reset ();
	} 
}
