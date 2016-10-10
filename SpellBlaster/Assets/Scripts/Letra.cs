using UnityEngine;
using System.Collections;

public class Letra : MonoBehaviour {


	public float maxHealth = 3.0f;
	public float health;

	public Material NoDamageMat;
	public Material MediumDamageMat;
	public Material criticalDamageMat;
	public Material IsIncorrectMat;
	public bool IsDestroyed;


	MeshRenderer meshRenderer;


	// Use this for initialization
	void Awake () {
	
		meshRenderer = GetComponent<MeshRenderer>();
		health = maxHealth; 
	}


	void Start()
	{
		CheckForDamage();

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

		if (!IsCorrect()) meshRenderer.material = IsIncorrectMat;
		

		if (health <= 0) {

			IsDestroyed = true;
		
		}
	}

	bool _isCorrect = true;
	public void SetIsCorrect(bool IsCorrect)
	{
		_isCorrect = IsCorrect;

	}

	public bool IsCorrect()
	{
		return _isCorrect;
	}

}
