using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public const float movementSpeed = 1;

	private Rigidbody rBody;
	private Vector3 movedirection;
	private Vector3 curMovement;

	private float friction = 0.9f;
	private float maxSpeed = 10f;
	private float acceleration = 1f;

	void Start () {
		rBody = GetComponent<Rigidbody>();
	}

	void Update () {
		float movementX = movedirection.x + -(Input.GetAxis("Vertical") * acceleration);
		float movementZ = movedirection.z + (Input.GetAxis("Horizontal") * acceleration);

		if (movementX > maxSpeed){
			movementX = maxSpeed;
		}
		if (movementX < -maxSpeed){
			movementX = -maxSpeed;
		}
		if (movementZ > maxSpeed){
			movementZ = maxSpeed;
		}
		if (movementZ < -maxSpeed){
			movementZ = -maxSpeed;
		}

		curMovement = new Vector3(movementX, 0, movementZ);
		movedirection = curMovement;
		movedirection = new Vector3(movedirection.x * friction, 0, movedirection.z * friction);
		//curMovement = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

		rBody.MovePosition(rBody.position + (movedirection * movementSpeed * Time.deltaTime));
	}
}
