using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectRobot: MonoBehaviour{


	private float left1 = 0f;
	private float left2 = 0f;
	private float left3 = 0f;
	private float left4 = 0f;
	private float left5 = 0f;
	private float left6 = 0f;

	private float right1 = 0f;
	private float right2 = 0f;
	private float right3 = 0f;
	private float right4 = 0f;
	private float right5 = 0f;
	private float right6 = 0f;

	private float forward1 = 0f;
	private float forward2 = 0f;
	private float forward3 = 0f;
	private float forward4 = 0f;
	private float forward5 = 0f;
	private float forward6 = 0f;

	public float leftThreshold = configs.leftThreshold;
	public float rightThreshold = configs.rightThreshold;
	public float forwardThreshold = configs.forwardThreshold;

    private float directionChangeAmount = configs.directionChangeAmount;
    private float augmentAmount = configs.augmentAmount;

	public int fitness;
	private string color;

	public ColisionDetector colisionDetector;

	public GameObject bug;
	public GameObject startPosition;


	public InsectRobot(){
		Debug.Log ("insect robot");
		bug = (GameObject)Instantiate (Resources.Load ("Player"));
		colisionDetector = bug.GetComponent<ColisionDetector> ();

		if (startPosition == null) {
			startPosition = GameObject.Find("StartPosition2");
		}
		resetPosition ();
		bug.layer = 8;
	}

	public InsectRobot(InsectRobot ir){
		Debug.Log ("insect robot");
		bug = (GameObject)Instantiate (Resources.Load ("Player"));
		colisionDetector = bug.GetComponent<ColisionDetector> ();

		if (startPosition == null) {
			startPosition = GameObject.Find("StartPosition2");
		}
		resetPosition ();
		bug.layer = 8;

		left1 = ir.left1;
		left2 = ir.left2;
		left3 = ir.left3;
		left4 = ir.left4;
		left5 = ir.left5;
		left6 = ir.left6;

		right1 = ir.right1;
		right2 = ir.right2;
		right3 = ir.right3;
		right4 = ir.right4;
		right5 = ir.right5;
		right6 = ir.right6;

		forward1 = ir.forward1;
		forward2 = ir.forward2;
		forward3 = ir.forward3;
		forward4 = ir.forward4;
		forward5 = ir.forward5;
		forward6 = ir.forward6;		

		leftThreshold = ir.leftThreshold;
		rightThreshold = ir.rightThreshold;
		forwardThreshold = ir.forwardThreshold;
	}

	public void resetPosition(){
		bug.transform.position = startPosition.transform.position;
		bug.transform.rotation = startPosition.transform.rotation;
		fitness = 0;
		colisionDetector.isDead = false;
	}

	public void setFitness(int fitness){
		this.fitness = fitness;
	} 
	public int getFitness(){
		return this.fitness;
	}
	public void destroy(){
		Destroy (bug);
	}

	public void augment(){
		left1 += Random.Range(-augmentAmount,augmentAmount);
		left2 += Random.Range(-augmentAmount,augmentAmount);
		left3 += Random.Range(-augmentAmount,augmentAmount);
		left4 += Random.Range(-augmentAmount,augmentAmount);
		left5 += Random.Range(-augmentAmount,augmentAmount);
		left6 += Random.Range(-augmentAmount,augmentAmount);

		right1 += Random.Range(-augmentAmount,augmentAmount);
		right2 += Random.Range(-augmentAmount,augmentAmount);
		right3 += Random.Range(-augmentAmount,augmentAmount);
		right4 += Random.Range(-augmentAmount,augmentAmount);
		right5 += Random.Range(-augmentAmount,augmentAmount);
		right6 += Random.Range(-augmentAmount,augmentAmount);

		forward1 += Random.Range(-augmentAmount,augmentAmount);
		forward2 += Random.Range(-augmentAmount,augmentAmount);
		forward3 += Random.Range(-augmentAmount,augmentAmount);
		forward4 += Random.Range(-augmentAmount,augmentAmount);
		forward5 += Random.Range(-augmentAmount,augmentAmount);
		forward6 += Random.Range(-augmentAmount,augmentAmount);

		forwardThreshold += Random.Range(-augmentAmount,augmentAmount);
		leftThreshold += Random.Range(-augmentAmount,augmentAmount);
		rightThreshold += Random.Range(-augmentAmount,augmentAmount);
	}

	public float getLeftNumber(float x1, float x2, float x3, float x4, float x5){
		float result = x1 * left1 +
			x2 * left2 +
			x3 * left3 +
			x4 * left4 +
			x5 * left5 +
			left6;
		return result;
	}

	public float getRightNumber(float x1, float x2, float x3, float x4, float x5){
		float result = x1 * right1 +
			x2 * right2 +
			x3 * right3 +
			x4 * right4 +
			x5 * right5 +
			right6;
		return result;
	}

	public float getForwardNumber(float x1, float x2, float x3, float x4, float x5){
		float result = (x1 * forward1) +
			(x2 * forward2) +
			(x3 * forward3) +
			(x4 * forward4) +
			(x5 * forward5) +
			(forward6);
		return result;
	}



	public void makeAMove(){
		//Debug.Log ("makeAMove");
		//Debug.Log ("This"+this);
		//Debug.Log ("bug x "+bug.transform.position.x);

		RaycastHit hit;
		float leftDistance = 0f;
		float frontLeftDistance = 0f;
		float frontDistance = 0f;
		float frontRightDistance = 0f;
		float rightDistance = 0f;
		int layerMask = 1 << 8;
		layerMask = ~layerMask;

		if (Physics.Raycast(this.bug.transform.position, -this.bug.transform.right, out hit, Mathf.Infinity, layerMask)) {
			leftDistance = hit.distance;
		}
		if (Physics.Raycast(this.bug.transform.position, this.bug.transform.forward-this.bug.transform.right, out hit, Mathf.Infinity, layerMask)) {
			frontLeftDistance = hit.distance;
		}
		if (Physics.Raycast(this.bug.transform.position, this.bug.transform.forward, out hit, Mathf.Infinity, layerMask)) {
			frontDistance = hit.distance;
		}
		if (Physics.Raycast(this.bug.transform.position, this.bug.transform.forward+this.bug.transform.right, out hit, Mathf.Infinity, layerMask)) {
			frontRightDistance = hit.distance;
		}
		if (Physics.Raycast(this.bug.transform.position, this.bug.transform.right, out hit, Mathf.Infinity, layerMask)) {
			rightDistance = hit.distance;
		}

		if (!colisionDetector.isDead) {

			if (getRightNumber(leftDistance, frontLeftDistance, frontDistance, frontRightDistance, rightDistance)>rightThreshold) {
				this.bug.transform.Rotate (0, directionChangeAmount, 0);
			} 
			if (getLeftNumber(leftDistance, frontLeftDistance, frontDistance, frontRightDistance, rightDistance)>leftThreshold) {
				this.bug.transform.Rotate (0, -directionChangeAmount, 0);
			}
			if (getForwardNumber(leftDistance, frontLeftDistance, frontDistance, frontRightDistance, rightDistance) > forwardThreshold) {
				this.bug.transform.position += (this.bug.transform.forward*0.1f);
				fitness++;
			}

		}
	}
}
