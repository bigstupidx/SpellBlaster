using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {



	[SerializeField]
	string currentScore;

	#region Numeros

	public GameObject _1Prefab;
	public GameObject _2Prefab;
	public GameObject _3Prefab;
	public GameObject _4Prefab;
	public GameObject _5Prefab;
	public GameObject _6Prefab;
	public GameObject _7Prefab;
	public GameObject _8Prefab;
	public GameObject _9Prefab;
	public GameObject _0Prefab;

	#endregion

	void Awake()
	{
		positions = gameObject.GetComponentsInChildren<LetterPosition>();

		CleanupPositions();
	}



	public List<GameObject> score;

	public LetterPosition[] positions;


	public bool wordWrong = false;
	public void SetScore(string Value)
	{

		

		CleanupPositions();

		currentScore = Value;

		score.Clear();

		int i = 0;
		foreach(char n in currentScore)
		{

			#region Search
			GameObject letter;


			switch(n)
			{

				case '1':
					letter = Instantiate(_1Prefab);
					break;
				case '2':
					letter = Instantiate(_2Prefab);
					break;
				case '3':
					letter = Instantiate(_3Prefab);
					break;
				case '4':
					letter = Instantiate(_4Prefab);
					break;
				case '5':
					letter = Instantiate(_5Prefab);
					break;

				case '6':
					letter = Instantiate(_6Prefab);
					break;

				case '7':
					letter = Instantiate(_7Prefab);
					break;

				case '8':
					letter = Instantiate(_8Prefab);
					break;

				case '9':
					letter = Instantiate(_9Prefab);
					break;

				case '0':
					letter = Instantiate(_0Prefab);
					break;


				default:
					letter = Instantiate(_0Prefab);
					break;
			}
			#endregion


			letter.transform.SetParent(positions[positions.Length - currentScore.Length - i].transform);
			letter.transform.localScale = Vector3.one;


			letter.transform.localPosition = Vector3.zero;


			score.Add(letter);

			i--;

		}



	}


	void CleanupPositions()
	{
		
		//foreach(LetterPosition lp in positions)

		for(int i = 0; i < positions.Length; i++)

		{
			LetterPosition lp = positions[i];

			Numero l = lp.transform.GetComponentInChildren<Numero> ();

			if(l) 
					Destroy(l.gameObject);
		}
	}


	void Update()
	{
		



	}



}

