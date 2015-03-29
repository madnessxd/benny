using UnityEngine;
using System.Collections;

public class Enemy : Humanoid {
	Transform[] neighbours;
	// Use this for initialization				
	float skinColor = 0;
	float hatColor = 0;
	float height = 0;
	float width = 0;
	float headSize = 0;
	float headShape = 0;

	private float[] functional;
	private float[] cosmetics;
	private static int[] links;

	private Transform model;
	private Renderer renderer;

	Vector3 moveDirection;
	Vector3 curPosition;

	private Rigidbody rBody;

	private Vector3 lastKillPos;

	private float runDist = 30;

	void setDirection (Vector3 direction){
		moveDirection = direction;
	}

	void run (Vector3 playerPos){
		float dist = Mathf.Sqrt(Mathf.Pow(curPosition.x - playerPos.x, 2) + Mathf.Pow(curPosition.z - playerPos.z, 2));
		if (dist < (runDist - 1)){
			setDirection((curPosition - playerPos) / dist);
			setDirection(new Vector3(moveDirection.x, 0, moveDirection.z));
		}
		lastKillPos = playerPos;
	}

	float killPosDist() {
		float dist = Mathf.Sqrt(Mathf.Pow(curPosition.x - lastKillPos.x, 2) + Mathf.Pow(curPosition.z - lastKillPos.z, 2));

		return dist;
	}

	void reset (){
		lastKillPos = curPosition;
		randomDir();
	}

	void setPosition (Vector3 position){
		curPosition = position;
	}

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

	void paintChildren(Transform a)	{
		foreach (Transform b in a)
		{
			if(b.GetComponent<Renderer>()){
				foreach(Renderer r in b.GetComponents<Renderer> ()) {
					for(int i = 0 ; i < r.materials.Length ; i++){ 
						float colR = 1f;
						float colG = 1f;
						float colB = 0f;	

						/*if(r.materials[i].name.Equals("Trim 2 (Instance)")){
							colR = skinColor; colG = headSize;
						}*/

						switch(r.materials[i].name){
							case "Trim 2 (Instance)": colR = skinColor; colG = headSize; break;
							case "Skin 2 (Instance)": colG = hatColor; colB = headShape; break;
							case "ColorVariation 2 (Instance)": colR = skinColor; colB = height; break;
							case "ColorIllum 2 (Instance)": colR = width; colB = hatColor; break;
						}
						r.materials[i].SetColor("_Color", new Color(colR, colG, colB));
					}
				}
			}
			paintChildren(b);
		}
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
		height = cosmetics[2];
		width = cosmetics[3];
		headSize = cosmetics[4];
		headShape = cosmetics[5];

		//speed = Mathf.Round(speed);
		sight = Mathf.Round(sight);
		//resistance = Mathf.Round(resistance);
		strength = Mathf.Round(strength);

		skinColor = Mathf.Round(skinColor);
		hatColor = Mathf.Round(hatColor);
		width = Mathf.Round(width);
		height = Mathf.Round(height);
		headSize = Mathf.Round(headSize);
		headShape = Mathf.Round(headShape);

		transform.localScale += new Vector3(width * 0.5f, height * 0.5f, width * 0.5f);
	}

	void randomDir () {		
		moveDirection = new Vector3((Random.value * 2) - 1, 0, (Random.value * 2) - 1);
		float vecLength = Mathf.Sqrt(Mathf.Pow(moveDirection.x, 2) + Mathf.Pow(moveDirection.z, 2));
		moveDirection = new Vector3(moveDirection.x / vecLength, 0, moveDirection.z / vecLength);
	}

	void Start () {
		rBody = GetComponent<Rigidbody>();
		randomDir();
		curPosition = transform.position;

		getStats();
		paintChildren(transform);
	}

	void Update () {
		//calculateNeighbours();
		if(killPosDist() > runDist + 1){
			reset();
		}

		move ();
		float rotY = Mathf.Atan2(moveDirection.x, moveDirection.z) / Mathf.PI * 180;
		if(!float.IsNaN(rotY)){
			rBody.transform.rotation = Quaternion.Euler(0, rotY, 0);
		}
	}

	void move () {
		curPosition = curPosition + (moveDirection * speed * 5 * Time.deltaTime);	
		rBody.transform.position = curPosition;

	}

	/*float centerize(){
	}

	float avoid() {
	}

	float match () {
	}*/

	void calculateNeighbours(){
		int threshold = 100;

		/*
		neighbours = [];

		if(neighbours.Length <= 0)
			for each Enemy 
		{
			if( Distance To Enemy < threshold 
			neighbours.push( Enemy ) ;
		}
		*/

		//neighbours = EnemySpawner.enemies;
		//Debug.Log(neighbours.Length);
	}
}
