using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public Transform enemy;	
	private int numberOfEnemies = 10;
	//Transform[] enemies = new Transform[numberOfEnemies];

	/*Transform spawnRandom() {
		Instantiate(enemy, new Vector3(Random.value * 20 - 10, 1f, Random.Range(-10, 10)), Quaternion.identity);
	}*/

	void Spawn(int number)
	{
		for(int i = 0 ; i < number ; i++){
			//spawnRandom();
			Instantiate(enemy, new Vector3(Random.value * 20 - 10, 3f, Random.Range(-10, 10)), Quaternion.identity);
		}
	}
	// Use this for initialization
	void Start () {
		Spawn(10);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
