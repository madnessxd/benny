using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	private Rigidbody rBody;

	void OnCollisionEnter (Collision col)
	{
		Debug.Log(col.gameObject.name);
		if(col.gameObject.name == "Enemy(Clone)")
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			for (int i = 0 ; i < enemies.Length ; i++){			
				enemies[i].SendMessage ("run", rBody.position);
			}
			Destroy(col.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
