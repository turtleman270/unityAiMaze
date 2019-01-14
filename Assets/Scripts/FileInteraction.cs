using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public static class FileInteraction {

	public static int rows = 10;	//number of different bugs that'll run
	public static int cols = 7;	//number of attributes
	static int maxNum = 100;
	static string filePath = Application.dataPath+"/Scripts/StorageFile.txt";

	public static int storedx1 = 0;
	public static int storedx2 = 0;
	public static int storedx3 = 0;
	public static int storedx4 = 0;
	public static int storedx5 = 0;
	public static int storedx6 = 0;
	public static int storedx7 = 0;

	public static float startTime = 0;

	public static int currentRobot = -1;


	//file format
	//each line represents one robot
	//the first 5 numbers are the x values that modify the input values
	//the last number represents the succes (distance travelled or time alive)

	static int[] randomXValues(int max){
		System.Random rnd = new System.Random();
		int[] xValues = new int[]{
			rnd.Next(0, max), 
			rnd.Next(0, max), 
			rnd.Next(0, max), 
			rnd.Next(0, max), 
			rnd.Next(0, max),
			rnd.Next(0, max) };
		return xValues;
	}
	static int[] augment(int[] xValues){
		System.Random rnd = new System.Random();
		xValues [0] += rnd.Next(-1, 1);
		xValues [1] += rnd.Next(-1, 1);
		xValues [2] += rnd.Next(-1, 1);
		xValues [3] += rnd.Next(-1, 1);
		xValues [4] += rnd.Next(-1, 1);
		xValues [5] += rnd.Next(-1, 1);
		return xValues;
	}

	static int augmentValue(int xValue){
		System.Random rnd = new System.Random ();
		return xValue + rnd.Next (-5, 5);
	}

	public static void sortAndDelete(){
		int[,] a = new int[rows, cols];
		getArrayFromFile (out a);
		//apparently 2d arrays are a no-no in c#
		//there are workarounds but id need to compile and 
		//reference shit, but fuck that, so bubble sort i guess

		bool changeWasMade = true;
		while (changeWasMade) {
			changeWasMade = false;
			for (int i = 0; i < rows; i++) {
				int startValue = a [i,6];
				for (int j = i+1; j < rows; j++) {
					int currentValue = a [j, 6];
					if (startValue < currentValue) {
						//swap the rows
						changeWasMade = true;
						int[] temp = new int[cols];
						for (int k = 0; k < cols; k++) {
							temp [k] = a [i, k];
						}
						for (int m = 0; m < cols; m++) {
							a [i, m] = a [j, m];
							a [j, m] = temp [m];
						}
					}
				}
			}
		}
		//"delete the losers"
		for (int i = rows / 2; i < rows; i++) {
			for (int j = 0; j < cols; j++) {
				a [i, j] = 0;
			}
		}
		loadFileWithArrayValues (a);
	}

	public static void breedWinners(){
		int[,] a = new int[rows, cols];
		getArrayFromFile (out a);
		System.Random rnd = new System.Random ();
		for (int i = 0; i < rows / 2; i++) {
			for (int j = 0; j < cols; j++) {
				int currentNum = a [i, j];
				a [i, j] = currentNum + rnd.Next (-20, 20);
				a [i + rows / 2, j] = currentNum + rnd.Next (-20, 20);
			}
		}
		loadFileWithArrayValues (a);
	}

	public static void updateFileWithCurrentValues(){
		int[,] a = new int[rows, cols];
		getArrayFromFile (out a);
		a [currentRobot, cols - 1] = (int)(Time.time*1000 - startTime*1000);
		loadFileWithArrayValues (a);
	}

	public static void getArrayFromFile(out int[,] array){
		array = new int[rows, cols];
		String[] lines = System.IO.File.ReadAllLines (filePath);
		for (int i = 0; i < lines.Length; i++) {
			String[] currentLine = lines [i].Split (',');
			for (int j = 0; j < currentLine.Length; j++) {
				array [i, j] = int.Parse (currentLine [j]);
			}
		}
	}

	public static void loadFileWithStartValues(){
		System.IO.File.Delete (filePath);
		for (int i = 0; i < rows; i++) {
			int[] currentRow = randomXValues (maxNum);
			for (int j = 0; j < currentRow.Length; j++) {
				System.IO.File.AppendAllText (filePath, ""+currentRow [j]+",");
			}
			System.IO.File.AppendAllText (filePath, "0");
			System.IO.File.AppendAllText (filePath, "\n");
		}
	}

	public static void loadFileWithArrayValues(int[,] fileValues){
		System.IO.File.Delete (filePath);
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < cols; j++) {
				if (j == cols - 1) {
					System.IO.File.AppendAllText (filePath, ""+fileValues[i,j]);
				} else {
					System.IO.File.AppendAllText (filePath, ""+fileValues[i,j]+",");
				}
			}
			System.IO.File.AppendAllText (filePath, "\n");
		}
	}

	public static int sum(
		int distLeft, int distLeftUp, int distUp, int distUpRight, int distRight,
		int x1, int x2, int x3, int x4, int x5, int x6){

		int sum = 
			distLeft * x1 +
			distLeftUp * x2 +
			distUp * x3 +
			distUpRight * x4 +
			distRight * x5 +
			x6;
		return sum;
	}
}
