using UnityEngine;
using System.Collections;

public class PlayerController : Humanoid {

	public const float movementSpeed = 1;

	private Rigidbody rBody;
	private Renderer renderer;
	private Vector3 movedirection;

	private float friction = 0.9f;
	private float maxSpeed = 10f;
	private float acceleration = 1f;

	private int cameraDist = 20;

	private Vector3 movement = new Vector3();


	Camera camera;

	void Start () {
		rBody = GetComponent<Rigidbody>();
		camera = Camera.mainCamera;
	}

	void Update () {
		//get input
		movement.x += (Input.GetAxis("Horizontal"));// * acceleration);
		movement.z += (Input.GetAxis("Vertical"));// * acceleration);


		
		// Friction
		movement *= friction;

		//set to maxSpeed
		/*if (movement.x > maxSpeed){
			movement.x = maxSpeed;
		}
		if (movement.x < -maxSpeed){
			movement.x = -maxSpeed;
		}
		if (movement.z > maxSpeed){
			movement.z = maxSpeed;
		}
		if (movement.z < -maxSpeed){
			movement.z = -maxSpeed;
		}* /


		//move camera x + z to player
		*/
/**/
		//move player
		rBody.MovePosition(rBody.position + movement * Time.deltaTime);
		//rBody.rotation = new Quaternion(0,1,0,1);
		/*
		*/

		float ease = .9f;
		float dX = ease * camera.transform.position.x + (1-ease) * rBody.position.x;
		float dZ = ease * camera.transform.position.z + (1-ease) * rBody.position.z;

		float vecLength = Mathf.Sqrt(Mathf.Pow(movement.x, 2) + Mathf.Pow(movement.z, 2));
		float vecX = Mathf.Acos(movement.x / vecLength);
		float vecZ = Mathf.Asin(movement.z / vecLength);

		//Debug.Log(vecX / Mathf.PI * 180);
		Debug.Log(Mathf.Atan2(vecZ, vecX) / Mathf.PI * 360);

		rBody.transform.rotation = Quaternion.Euler(0, Mathf.Atan2(vecZ, vecX) / Mathf.PI * 360 - 90, 0);

		camera.transform.position = new Vector3(dX, cameraDist, dZ);
		//camera.transform.position = new Vector3(0, cameraDist, 0);
		//camera.transform.position.y = -10;
	}
}
