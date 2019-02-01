using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class configs{
    public static float leftThreshold = 0f;
    public static float rightThreshold = 0f;
    public static float forwardThreshold = 0f;

    public static float directionChangeAmount = 3f;
    public static float augmentAmount = 0.01f;

    public static float addRobotsAmount = 30;

    public static bool displayDataOnScreen = true;

    public static float maxRunTime = 20f;
    
    private static Vector3 startPos1 = new Vector3 (2.27f, 0.53f, -7.96f);
    private static Quaternion startRot1 = Quaternion.Euler(0f, -90f, 0f);

	private static Vector3 startPos2 = new Vector3 (-26f, 0.53f, -13.5f);
	private static Quaternion startRot2 = Quaternion.Euler (0f, -90f, 0f);




	public static Vector3 startPos = startPos2;
	public static Quaternion startRot = startRot2;
}
