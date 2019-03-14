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

	public static int desiredMazeNum = 1;



	// Maze setup
	private static Quaternion defaultRobotRot = Quaternion.Euler(0f, -90f, 0f);
	private static Quaternion defaultCameraRot = Quaternion.Euler(80f, 0f, 0f);

	private static MazeInfo mazeZero = new MazeInfo(
		"Maze 1", 
		new Vector3(-26f, 0.53f, -13.5f), defaultRobotRot, 
		new Vector3(-29, 28, -9.5f), defaultCameraRot);

	private static MazeInfo mazeOne = new MazeInfo(
		"Maze 2",
		new Vector3(40f, 0f, 0f), defaultRobotRot,
		new Vector3(37, 28, -10), defaultCameraRot
		);


	public static MazeInfo[] listOfAllMazes = { mazeZero, mazeOne };
	public static MazeInfo maze = listOfAllMazes[desiredMazeNum];

	public static Vector3 startPos = maze.robotStartPos;
	public static Quaternion startRot = maze.robotStartRot;

	public static Vector3 cameraPos = maze.cameraPos;
	public static Quaternion cameraRot = maze.cameraRot;

	//Keyboard bindings
    public static KeyCode addRobotsKey = KeyCode.A;
    public static KeyCode sortKey = KeyCode.S;
    public static KeyCode deleteHalfKey = KeyCode.D;
    public static KeyCode replaceKey = KeyCode.F;
    public static KeyCode augmentKey = KeyCode.J;
    public static KeyCode repositionKey = KeyCode.K;
    public static KeyCode resetAndRunKey = KeyCode.L;
}
