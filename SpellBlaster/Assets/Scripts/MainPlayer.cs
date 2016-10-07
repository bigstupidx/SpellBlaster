using UnityEngine;
using System.Collections;

public class MainPlayer : MonoBehaviour {


	public float speed = 100.0f;
	public float bulletSpeed = 500.0f;

	//TODO: Make Bullets Reusable
	public GameObject bullet;
	public GameObject bulletInstancer;

	//TODO: Make Bounds Reusable
	public GameObject rightBound;
	public GameObject leftBound;

	Rigidbody rigidBody;

	// Use this for initialization
	void Awake() {

		rigidBody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		//TODO: Make Input Reusable
		if (Input.GetAxis ("Horizontal") > 0) {
			Move (1);
		}
		else if(Input.GetAxis("Horizontal") < 0){
			Move (-1);
		}
	
		if (Input.GetButtonDown ("Jump") || Input.GetMouseButtonDown(0)) {
		
			GameObject bulletShot = (GameObject) Instantiate (bullet, bulletInstancer.transform.position, Quaternion.identity);
			Rigidbody bulletRigidBody = bulletShot.GetComponent <Rigidbody> ();
			bulletRigidBody.AddForce ( Vector3.up * bulletSpeed * Time.deltaTime, ForceMode.VelocityChange);
			Destroy (bulletShot, 3.0f);
		}

		ShipPitch();
	}


	bool touchingRightLimit;
	bool touchingLeftLimit;
	void Move (int MoveDirection)
	{

		if(MoveDirection > 0 && !touchingRightLimit) 
			rigidBody.MovePosition (transform.position + Vector3.right * speed * Time.deltaTime);
		if(MoveDirection < 0 && !touchingLeftLimit)
			rigidBody.MovePosition (transform.position + Vector3.left * speed * Time.deltaTime);

		CheckShipLimits ();
	}


	void CheckShipLimits()
	{
		if (transform.position.x < rightBound.transform.position.x)
			touchingRightLimit = false;
		else
			touchingRightLimit = true;

		if (transform.position.x > leftBound.transform.position.x)
			touchingLeftLimit = false;
		else
			touchingLeftLimit = true;
	}


	void ShipPitch()
	{
		MeshRenderer meshRender = GetComponentInChildren<MeshRenderer>();
		Ray checkLeft = new Ray(meshRender.bounds.center, Vector3.left);
		Ray checkRight = new Ray(meshRender.bounds.center, Vector3.right);
		RaycastHit leftLimit;
		RaycastHit rightLimit;
		Physics.Raycast(checkLeft,out leftLimit);
		Physics.Raycast(checkRight,out rightLimit);
		float distanceToLeft = (meshRender.bounds.center - leftLimit.point).magnitude;
		float distanceToRight = (meshRender.bounds.center - rightLimit.point).magnitude;
		
//		Debug.Log("Distance to left gutter: " + leftLimit.collider.name + " is " + distanceToLeft );
//		Debug.Log("Distance to right gutter: " + rightLimit.collider.name + " is " + distanceToRight );
//		
		//Where center of the ball is
		Vector3 ballPosition = meshRender.bounds.center;
		
		//Where finger is positioned from the camera
		Ray fingerRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		//The line between the center of the ball and the finger's position
		Vector3 offset = fingerRay.origin - ballPosition;
				
		//A line from the ball in the direction of the finger's position
		Debug.DrawRay(ballPosition, offset, Color.green);
	
		//Distance between finger and ball
		float distance = offset.magnitude;
		
		//Direction from ball to finger
		Vector3 direction = offset / distance;
		
		//If X is positive, finger is on the right of the ball, if X is negative, finger is on the left
		Debug.Log(direction.x);

			float x = direction.x;
			
			
		if(x > 0.15 && distanceToRight > 0.18f)
		{
			transform.Translate(new Vector3(100.0f * distance / 1000f,0f,0f));			
		}
		if(x < -0.15 && distanceToLeft > 0.18f)
		{
			transform.Translate(new Vector3(-100.0f * distance / 1000f,0f,0f));
		}
		
	}
}
