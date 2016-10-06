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
	
		if (Input.GetButtonDown ("Jump")) {
		
			GameObject bulletShot = (GameObject) Instantiate (bullet, bulletInstancer.transform.position, Quaternion.identity);
			Rigidbody bulletRigidBody = bulletShot.GetComponent <Rigidbody> ();
			bulletRigidBody.AddForce ( Vector3.up * bulletSpeed * Time.deltaTime, ForceMode.VelocityChange);
			Destroy (bulletShot, 3.0f);
		}


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

}
