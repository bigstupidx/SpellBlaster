using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float damageValue = 1.0f;

	public GameObject particleEffect;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.GetComponent<Letra>())
			Destroy (((GameObject)Instantiate (particleEffect, col.transform.position, Quaternion.identity)).gameObject, 0.6f);
	}


}
