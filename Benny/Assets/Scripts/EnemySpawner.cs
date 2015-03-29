using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public Transform enemy;	
	private int numberOfEnemies = 10;
	//Transform[] enemies = new Transform[numberOfEnemies];

	/*Transform spawnRandom() {
		Instantiate(enemy, new Vector3(Random.value * 20 - 10, 1f, Random.Range(-10, 10)), Quaternion.identity);
	}*/

	// Use this for initialization
	void Start () {
		for(int i = 0 ; i < 10 ; i++){
			//spawnRandom();
			Instantiate(enemy, new Vector3(Random.value * 20 - 10, 1f, Random.Range(-10, 10)), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
