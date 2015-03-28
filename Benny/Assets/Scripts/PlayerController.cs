using UnityEngine;
using System.Collections;

public class PlayerController : Humanoid {

	public const float movementSpeed = 1;

	private Rigidbody rBody;
	private Renderer renderer;
	private Vector3 movedirection;
	private Vector3 curMovement;

	private float friction = 0.9f;
	private float maxSpeed = 10f;
	private float acceleration = 1f;

	private int cameraDist = 20;

	Camera camera;

	void Start () {
		rBody = GetComponent<Rigidbody>();
		camera = Camera.mainCamera;
	}

	void Update () {
		float movementX = movedirection.x + (Input.GetAxis("Horizontal") * acceleration);
		float movementZ = movedirection.z + (Input.GetAxis("Vertical") * acceleration);

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
		camera.transform.position = new Vector3(rBody.position.x, cameraDist, rBody.position.z - 10);
		rBody.MovePosition(rBody.position + (movedirection * movementSpeed * Time.deltaTime));
	}
}
