using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	// Use this for initialization
	float speed;
	float sight;
	float resistance;
	float strength;
				
	float skinColor;
	float hatColor;
	float hight;
	float width;
	float headSize;
	float headShape;

	private float[] functional;
	private float[] cosmetics;
	private static int[] links;

	void printFloatArray (float[] printArray) {
		string newString = "";
		for (int i = 0 ; i < printArray.Length ; i ++) {
			newString += printArray[i] + ", ";
		}
		Debug.Log(newString);
	}

	void printIntArray (int[] printArray) {
		string newString = "";
		for (int i = 0 ; i < printArray.Length ; i ++) {
			newString += printArray[i] + ", ";
		}
		Debug.Log(newString);
	}

	void getStats () {
		functional = new float[4];
		cosmetics = new float[6];

		for(int i = 0 ; i < functional.Length ; i++){
			functional[i] = Random.value;
		}

		if (links == null){
			links = new int[cosmetics.Length];
			for(int i = 0 ; i < links.Length ; i++){
				links[i] = Random.Range(0, functional.Length);
			}
		}

		for(int i = 0 ; i < cosmetics.Length ; i++){
			cosmetics[i] = functional[links[i]];
		}

		speed = functional[0];
		sight = functional[1];
		resistance = functional[2];
		strength = functional[3];

		skinColor = cosmetics[0];
		hatColor = cosmetics[1];
		hight = cosmetics[2];
		width = cosmetics[3];
		headSize = cosmetics[4];
		headShape = cosmetics[5];

		printFloatArray(functional);
		Debug.Log("-----");
		printFloatArray(cosmetics);
		Debug.Log("-----");
		printIntArray(links);
		Debug.Log("---END---");


	}

	void Start () {
		getStats();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
