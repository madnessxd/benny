using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {
	public Transform startPoint; //player (in z'n ironman belly)
	public Transform endPoint;	//target (moet dan dynamisch aangemaakt worden) maar waarschijnlijk met raycasting beter
	LineRenderer laserLine;
	
	void Start () {
		laserLine = GetComponentInChildren<LineRenderer> ();
		laserLine.SetWidth (0.2f, 0.2f);
	}
	
	void Update () {
		laserLine.SetPosition (0, startPoint.position);
		laserLine.SetPosition (1, endPoint.position);

	}
}
