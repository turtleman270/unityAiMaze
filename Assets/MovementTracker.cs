using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTracker : MonoBehaviour {

	public GameObject startPosition;
	public GameObject player;

	static float defaultDirectionMultiplier = 3f;
	static float defaultSpeed = 0.02f;
	static float speedIncrement = 0.02f;
	static float directionIncrement = 1f;
	static float minSpeed = 0.01f;

	float direction = 0;
	float directionMultiplier = defaultDirectionMultiplier;
	float speed = defaultSpeed;
	bool notDead = true;


	public bool isNotDead(){
		return notDead;
	}
	public void die(){
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
		player.transform.position = startPosition.transform.position;
		player.transform.rotation = startPosition.transform.rotation;
		directionMultiplier = defaultDirectionMultiplier;
		speed = defaultSpeed;
		direction = 0;
		notDead = true;
		Debug.Log (speed);
		Debug.Log (direction);
		Debug.Log (directionMultiplier);
	}
}
