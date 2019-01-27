using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTracker : MonoBehaviour {

	static float defaultDirectionMultiplier = configs.defaultDirectionMultiplier;
	static float defaultSpeed = configs.defaultSpeed;
	static float speedIncrement = configs.speedIncrement;
	static float directionIncrement = configs.directionIncrement;
	static float minSpeed = configs.minSpeed;

	float direction = 0;
	float directionMultiplier = defaultDirectionMultiplier;
	float speed = defaultSpeed;
	bool notDead = true;


	public bool isNotDead(){
		return notDead;
	}
	public void die(){
		FileInteraction.updateFileWithCurrentValues ();
		direction = 0;
		notDead = false;
	}


	//turning
	public float getTurnMultiplyer(){
		return directionMultiplier;
	}
	public void increaseTurn(){
		directionMultiplier += directionIncrement;
	}
	public void decreaseTurn(){
		directionMultiplier -= directionIncrement;
		if (directionMultiplier <= 0) {
			directionMultiplier = 1;
		}
	}
	public float getDirection(){
		return direction;
	}
	public void turnRight(){
		direction = directionMultiplier;
	}
	public void turnLeft(){
		direction = -directionMultiplier;
	}
	public void goStraight(){
		direction = 0;
	}

	//speed
	public void increaseSpeed(){
		speed += speedIncrement;
	}
	public void decreaseSpeed(){
		speed -= speedIncrement;
		if (speed < minSpeed) {
			speed = minSpeed;
		}
	}
	public float getSpeed(){
		return speed;
	}


	public void reset(){
		directionMultiplier = defaultDirectionMultiplier;
		speed = defaultSpeed;
		direction = 0;
		notDead = true;
		Debug.Log (speed);
		Debug.Log (direction);
		Debug.Log (directionMultiplier);
	}
}
