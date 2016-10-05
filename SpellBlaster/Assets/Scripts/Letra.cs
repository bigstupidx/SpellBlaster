using UnityEngine;
using System.Collections;

public class Letra : MonoBehaviour {


	public float maxHealth = 3.0f;
	public float health;

	public Material NoDamageMat;
	public Material MediumDamageMat;
	public Material criticalDamageMat;

	MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
	
		meshRenderer = GetComponent<MeshRenderer>();
		health = maxHealth; 
	}
	
	// Update is called once per frame
	void Update () {
	

	}


	void TakeDamage(float damage)
	{
		health -= damage;
		CheckForDamage ();
	}
		

	void OnCollisionEnter(Collision col)
	{

		Bullet bullet = col.gameObject.GetComponent<Bullet> ();
		if (bullet) 
		{
			TakeDamage (bullet.damageValue);
			Destroy (bullet.gameObject);
		}
	}

	void CheckForDamage()
	{

		if (health > maxHealth * (2.0 / 3.0))
			meshRenderer.material = NoDamageMat;
		else if (health > maxHealth * (1.0 / 3.0))
			meshRenderer.material = MediumDamageMat;
		else
			meshRenderer.material = criticalDamageMat;


		if (health <= 0) {

			Destroy (gameObject);
		
		}
	}

}
