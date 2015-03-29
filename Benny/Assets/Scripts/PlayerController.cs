using UnityEngine;
using System.Collections;

public class PlayerController : Humanoid {
	
	public Transform laserTrans;	
	private Transform laser;

	public const float movementSpeed = 1;
	public const float absorbRatio = .7f;

	private Rigidbody rBody;
	private Renderer renderer;
	private Vector3 movedirection;
	
	private float friction = 0.9f;
	private float maxSpeed = 0.2f;
	private float acceleration = 1f;
	
	private int cameraDist = 20;
	private float sight = .5f;

	private Vector3 movement = new Vector3();

	private float resistance = 0.2f;
	private float startLifeTime = 30;
	private float lifeTime = 30;

	private Transform gameOver;

	Camera camera;

	void Start () {
		//gameOver = GameObject.FindGameObjectWithTag ("GameOver");
		//gameOver.renderer.enabled = false;
		rBody = GetComponent<Rigidbody>();
		camera = Camera.mainCamera;
	}

	void BoostSpeed (float speed) {
		maxSpeed += speed;
	}

	void absorbSkills (GameObject enemy){
		float enemySpeed = enemy.gameObject.GetComponent<Enemy>().speed;
		float enemySight = enemy.gameObject.GetComponent<Enemy>().sight;
		float enemyResistance = enemy.gameObject.GetComponent<Enemy>().resistance;
		float enemyStrength = enemy.gameObject.GetComponent<Enemy>().strength;

		if(enemySight > sight){
			sight += ((enemySight - sight) * absorbRatio);
		}
		if(sight > 1){
			sight = 1;
		}

		if(enemySpeed > maxSpeed){
			maxSpeed += ((enemySpeed - maxSpeed) * absorbRatio);
		}
		if(maxSpeed > 1){
			maxSpeed = 1;
		}
		if(enemyResistance > resistance){
			resistance += ((enemyResistance - resistance) * absorbRatio);
		}
		if(resistance > 1){
			resistance = 1;
		}
		Debug.Log(enemyResistance);
		Debug.Log(resistance);
	}

	void setHealthbar(){
		GameObject healthBar = GameObject.FindGameObjectWithTag ("Healthbar");
		lifeTime -= (1 - resistance) * Time.deltaTime;

		float yScale = 8 * (lifeTime / startLifeTime);
		if(yScale < 0){
			yScale = 0;
		}
		if(yScale == 0){
			Time.timeScale = 0;
		}
		healthBar.transform.localScale = (new Vector3(1, yScale, 1));
	}

	void OnCollisionEnter (Collision col)
	{
		Debug.Log(col.gameObject.name);
		if(col.gameObject.name == "Enemy(Clone)")
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			for (int i = 0 ; i < enemies.Length ; i++){			
				enemies[i].SendMessage ("run", rBody.position);
			}
			absorbSkills(col.gameObject);
			Destroy(col.gameObject);	
		}
	}

	void Update () {
		//get input
		movement.x += (Input.GetAxis("Horizontal"));// * acceleration);
		movement.z += (Input.GetAxis("Vertical"));// * acceleration);
		
		// Friction
		movement *= friction;
		
		//set to maxSpeed
		if (movement.x > maxSpeed){
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
		}

		//move camera x + z to player
		//*/
		/**/
		//move player
		rBody.MovePosition(rBody.position + movement * 5 * Time.deltaTime);
		//rBody.rotation = new Quaternion(0,1,0,1);
		/*
		*/
		
		float ease = .9f;
		float dX = ease * camera.transform.position.x + (1-ease) * rBody.position.x;
		float dY = ease * camera.transform.position.y + (1-ease) * (cameraDist * sight);
		float dZ = ease * camera.transform.position.z + (1-ease) * rBody.position.z;

		
		float vecLength = Mathf.Sqrt(Mathf.Pow(movement.x, 2) + Mathf.Pow(movement.z, 2));
		float vecX = movement.x / vecLength;
		float vecZ = movement.z / vecLength;
		
		float rotY = Mathf.Atan2(vecX, vecZ) / Mathf.PI * 180;
		if(!float.IsNaN(rotY)){
			rBody.transform.rotation = Quaternion.Euler(0, rotY, 0);
		}
		camera.transform.position = new Vector3(dX, dY , dZ - (1f * (20 / cameraDist) * 0.5f));

		setHealthbar();
		//camera.transform.position = new Vector3(0, cameraDist, 0);
		//camera.transform.position.y = -10;
		//checkCollisions ();

		if(Input.GetKey("space")){
			if (laser == null){
				laser = Instantiate(laserTrans, new Vector3(rBody.transform.position.x + vecX, 0, rBody.transform.position.z + vecZ), rBody.transform.rotation) as Transform;
			} else {
				laser.transform.position = new Vector3(rBody.transform.position.x + vecX, 0, rBody.transform.position.z + vecZ);
				laser.transform.rotation = rBody.transform.rotation;
			}
		} else {
			if (laser != null){
				Destroy(laser.gameObject);
			}
		}
	}
}
