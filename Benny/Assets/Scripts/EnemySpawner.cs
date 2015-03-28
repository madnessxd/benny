using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public Transform enemy;

	void spawnRandom() {
		Instantiate(enemy, new Vector3(Random.value * 20 - 10, 0.5f, Random.Range(-10, 10)), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
		for(int i = 0 ; i < 10 ; i++){
			spawnRandom();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
