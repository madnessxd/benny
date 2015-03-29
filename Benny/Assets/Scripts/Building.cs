using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	void OnCollisionEnter (Collision col)
	{
		Debug.Log(col.gameObject.name);
		if(col.gameObject.name == "Enemy(Clone)")
		{
			col.gameObject.SendMessage("randomDir");
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
