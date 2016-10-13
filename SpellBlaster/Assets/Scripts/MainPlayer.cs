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

	public AudioClip bulletSound;

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
	
		if (Input.GetButtonUp ("Jump") || Input.GetMouseButtonUp(0)) {
		
			GameObject bulletShot = (GameObject) Instantiate (bullet, bulletInstancer.transform.position, Quaternion.identity);
			Rigidbody bulletRigidBody = bulletShot.GetComponent <Rigidbody> ();
			bulletRigidBody.AddForce ( Vector3.up * bulletSpeed * Time.deltaTime, ForceMode.VelocityChange);

			AudioSource.PlayClipAtPoint (bulletSound, transform.position);
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
		Vector3 tmp = new Vector3(Input.mousePosition.x,0,0);
		tmp.z = Mathf.Abs(Camera.main.transform.position.z);
		Vector3 newPosition = Camera.main.ScreenToWorldPoint(tmp);
		newPosition.y = transform.position.y;

		if((transform.position.x < newPosition.x && !touchingRightLimit) ||
		 (transform.position.x > newPosition.x && !touchingLeftLimit))
			transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
	
		CheckShipLimits();
	}
}
