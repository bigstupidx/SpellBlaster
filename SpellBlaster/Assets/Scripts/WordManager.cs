using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordManager : MonoBehaviour {



	[SerializeField]
	string wordInPlay;

	#region mayusculas

	public GameObject A_Mayuscula_Prefab;
	public GameObject B_Mayuscula_Prefab;
	public GameObject C_Mayuscula_Prefab;
	public GameObject D_Mayuscula_Prefab;
	public GameObject E_Mayuscula_Prefab;
	public GameObject F_Mayuscula_Prefab;
	public GameObject G_Mayuscula_Prefab;
	public GameObject H_Mayuscula_Prefab;
	public GameObject I_Mayuscula_Prefab;
	public GameObject J_Mayuscula_Prefab;
	public GameObject K_Mayuscula_Prefab;
	public GameObject L_Mayuscula_Prefab;
	public GameObject M_Mayuscula_Prefab;
	public GameObject N_Mayuscula_Prefab;
	public GameObject O_Mayuscula_Prefab;
	public GameObject P_Mayuscula_Prefab;
	public GameObject Q_Mayuscula_Prefab;
	public GameObject R_Mayuscula_Prefab;
	public GameObject S_Mayuscula_Prefab;
	public GameObject T_Mayuscula_Prefab;
	public GameObject U_Mayuscula_Prefab;
	public GameObject V_Mayuscula_Prefab;
	public GameObject W_Mayuscula_Prefab;
	public GameObject X_Mayuscula_Prefab;
	public GameObject Y_Mayuscula_Prefab;
	public GameObject Z_Mayuscula_Prefab;

	#endregion

	#region Minusculas 

	public GameObject a_Minuscula_Prefab;
	public GameObject b_Minuscula_Prefab;
	public GameObject c_Minuscula_Prefab;
	public GameObject d_Minuscula_Prefab;
	public GameObject e_Minuscula_Prefab;
	public GameObject f_Minuscula_Prefab;
	public GameObject g_Minuscula_Prefab;
	public GameObject h_Minuscula_Prefab;
	public GameObject i_Minuscula_Prefab;
	public GameObject j_Minuscula_Prefab;
	public GameObject k_Minuscula_Prefab;
	public GameObject l_Minuscula_Prefab;
	public GameObject m_Minuscula_Prefab;
	public GameObject n_Minuscula_Prefab;
	public GameObject o_Minuscula_Prefab;
	public GameObject p_Minuscula_Prefab;
	public GameObject q_Minuscula_Prefab;
	public GameObject r_Minuscula_Prefab;
	public GameObject s_Minuscula_Prefab;
	public GameObject t_Minuscula_Prefab;
	public GameObject u_Minuscula_Prefab;
	public GameObject v_Minuscula_Prefab;
	public GameObject w_Minuscula_Prefab;
	public GameObject x_Minuscula_Prefab;
	public GameObject y_Minuscula_Prefab;
	public GameObject z_Minuscula_Prefab;

	#endregion


	#region Especiales
	public GameObject a_Acento_Minuscula_Prefab;
	public GameObject e_Acento_Minuscula_Prefab;
	public GameObject i_Acento_Minuscula_Prefab;
	public GameObject o_Acento_Minuscula_Prefab;
	public GameObject u_Acento_Minuscula_Prefab;
	public GameObject u_Dieresis_Minuscula_Prefab;
	public GameObject nie_Minuscula_Prefab;

	public GameObject A_Acento_Mayuscula_Prefab;
	public GameObject E_Acento_Mayuscula_Prefab;
	public GameObject I_Acento_Mayuscula_Prefab;
	public GameObject O_Acento_Mayuscula_Prefab;
	public GameObject U_Acento_Mayuscula_Prefab;
	public GameObject u_Dieresis_Mayuscula_Prefab;
	public GameObject Nie_Mayuscula_Prefab;

	#endregion

	void Awake()
	{
		positions = gameObject.GetComponentsInChildren<LetterPosition>();
		CleanupPositions();
	}



	public List<GameObject> builtWord;

	public LetterPosition[] positions;

	public WordType myWordType;

	public enum WordType
	{
		misspelledSingle, misspelledMultiple, nonExistent
	}


	public bool wordWrong = false;
	public void SetWordInPlay(string Value, int PosicionIncorrecta)
	{
		myWordType = WordType.misspelledSingle;

		wordInPlay = Value;

		builtWord.Clear();

		wordWrong = false;

		int i = 0;
		foreach(char ch in wordInPlay)
		{

			#region Search
			GameObject letter;


			switch(ch)
			{
				case 'A':
						letter = Instantiate(A_Mayuscula_Prefab);
						break;
				case 'B':
						letter = Instantiate(B_Mayuscula_Prefab);
						break;
				case 'C':
						letter = Instantiate(C_Mayuscula_Prefab);
						break;
				case 'D':
						letter = Instantiate(D_Mayuscula_Prefab);
						break;
				case 'E':
						letter = Instantiate(E_Mayuscula_Prefab);
						break;
				case 'F':
						letter = Instantiate(F_Mayuscula_Prefab);
						break;
				case 'G':
						letter = Instantiate(G_Mayuscula_Prefab);
						break;
				case 'H':
						letter = Instantiate(H_Mayuscula_Prefab);
						break;
				case 'I':
						letter = Instantiate(I_Mayuscula_Prefab);
						break;
				case 'J':
						letter = Instantiate(J_Mayuscula_Prefab);
						break;
				case 'K':
						letter = Instantiate(K_Mayuscula_Prefab);
						break;
				case 'L':
						letter = Instantiate(L_Mayuscula_Prefab);
						break;
				case 'M':
						letter = Instantiate(M_Mayuscula_Prefab);
						break;
				case 'N':
						letter = Instantiate(N_Mayuscula_Prefab);
						break;
				case 'O':
						letter = Instantiate(O_Mayuscula_Prefab);
						break;
				case 'P':
						letter = Instantiate(P_Mayuscula_Prefab);
						break;
				case 'Q':
						letter = Instantiate(Q_Mayuscula_Prefab);
						break;
				case 'R':
						letter = Instantiate(R_Mayuscula_Prefab);
						break;
				case 'S':
						letter = Instantiate(S_Mayuscula_Prefab);
						break;
				case 'T':
						letter = Instantiate(T_Mayuscula_Prefab);
						break;
				case 'U':
						letter = Instantiate(U_Mayuscula_Prefab);
						break;
				case 'V':
						letter = Instantiate(V_Mayuscula_Prefab);
						break;
				case 'W':
						letter = Instantiate(W_Mayuscula_Prefab);
						break;
				case 'X':
						letter = Instantiate(X_Mayuscula_Prefab);
						break;
				case 'Y':
						letter = Instantiate(Y_Mayuscula_Prefab);
						break;
				case 'Z':
						letter = Instantiate(Z_Mayuscula_Prefab);
						break;




				case 'a':
						letter = Instantiate(a_Minuscula_Prefab);
						break;
				case 'b':
						letter = Instantiate(b_Minuscula_Prefab);
						break;
				case 'c':
						letter = Instantiate(c_Minuscula_Prefab);
						break;
				case 'd':
						letter = Instantiate(d_Minuscula_Prefab);
						break;
				case 'e':
						letter = Instantiate(e_Minuscula_Prefab);
						break;
				case 'f':
						letter = Instantiate(f_Minuscula_Prefab);
						break;
				case 'g':
						letter = Instantiate(g_Minuscula_Prefab);
						break;
				case 'h':
						letter = Instantiate(h_Minuscula_Prefab);
						break;
				case 'i':
						letter = Instantiate(i_Minuscula_Prefab);
						break;
				case 'j':
						letter = Instantiate(j_Minuscula_Prefab);
						break;
				case 'k':
						letter = Instantiate(k_Minuscula_Prefab);
						break;
				case 'l':
						letter = Instantiate(l_Minuscula_Prefab);
						break;
				case 'm':
						letter = Instantiate(m_Minuscula_Prefab);
						break;
				case 'n':
						letter = Instantiate(n_Minuscula_Prefab);
						break;
				case 'o':
						letter = Instantiate(o_Minuscula_Prefab);
						break;
				case 'p':
						letter = Instantiate(p_Minuscula_Prefab);
						break;
				case 'q':
						letter = Instantiate(q_Minuscula_Prefab);
						break;
				case 'r':
						letter = Instantiate(r_Minuscula_Prefab);
						break;
				case 's':
						letter = Instantiate(s_Minuscula_Prefab);
						break;
				case 't':
						letter = Instantiate(t_Minuscula_Prefab);
						break;
				case 'u':
						letter = Instantiate(u_Minuscula_Prefab);
						break;
				case 'v':
						letter = Instantiate(v_Minuscula_Prefab);
						break;
				case 'w':
						letter = Instantiate(w_Minuscula_Prefab);
						break;
				case 'x':
						letter = Instantiate(x_Minuscula_Prefab);
						break;
				case 'y':
						letter = Instantiate(y_Minuscula_Prefab);
						break;
				case 'z':
						letter = Instantiate(z_Minuscula_Prefab);
						break;

				case 'á':
					letter = Instantiate(a_Acento_Minuscula_Prefab);
					break;
				case 'é':
					letter = Instantiate(e_Acento_Minuscula_Prefab);
					break;
				case 'í':
					letter = Instantiate(i_Acento_Minuscula_Prefab);
					break;
				case 'ó':
					letter = Instantiate(o_Acento_Minuscula_Prefab);
					break;
				case 'ú':
					letter = Instantiate(u_Acento_Minuscula_Prefab);
					break;


				case 'Á':
					letter = Instantiate(A_Acento_Mayuscula_Prefab);
					break;
				case 'É':
					letter = Instantiate(E_Acento_Mayuscula_Prefab);
					break;
				case 'Í':
					letter = Instantiate(I_Acento_Mayuscula_Prefab);
					break;
				case 'Ó':
					letter = Instantiate(O_Acento_Mayuscula_Prefab);
					break;
				case 'Ú':
					letter = Instantiate(U_Acento_Mayuscula_Prefab);
					break;

				case 'ü':
					letter = Instantiate(u_Dieresis_Minuscula_Prefab);
					break;

				case 'Ü':
					letter = Instantiate(u_Dieresis_Mayuscula_Prefab);
					break;

				case 'ñ':
					letter = Instantiate(nie_Minuscula_Prefab);
					break;

				case 'Ñ':
					letter = Instantiate(Nie_Mayuscula_Prefab);
					break;


				default:
					letter = Instantiate(J_Mayuscula_Prefab);
					break;
			}
			#endregion


			letter.transform.SetParent(positions[i].transform);
			letter.transform.localPosition = Vector3.zero;

			if (i == PosicionIncorrecta) {
				letter.GetComponent<Letra> ().SetIsCorrect (false);
			}

			builtWord.Add(letter);

			i++;




			if (i >= positions.Length)
				break;
		}



//		foreach(GameObject letter in builtWord)
//		{
			//GameObject let = (GameObject)Instantiate(letter, letter.transform.position, Quaternion.identity, positions[i].transform);

			//letter.transform.SetParent(positions[i].transform);



			//Letra l = let.GetComponent<Letra>();

			//if(i == 3) l.SetIsCorrect(false);

			//i++;
		//}

	}


	void CleanupPositions()
	{
		
		//foreach(LetterPosition lp in positions)

		for(int i = 0; i < positions.Length; i++)

		{
			LetterPosition lp = positions[i];

			Letra l = lp.transform.GetComponentInChildren<Letra> ();

			if(l) 
					Destroy(l.gameObject);
		}
	}


	void Update()
	{
		


		CheckDestroyedLetters();
	}



	public void DestroyWordInPlay()
	{

		for(int i = 0; i < builtWord.Count; i++)
		{
			GameObject g = builtWord[i];

			Animation a = g.GetComponent<Animation> ();
			if (a)
				a.Stop (); 

			Rigidbody rb = g.AddComponent<Rigidbody>();

			if(rb)
				rb.AddForceAtPosition(Vector3.up * 100.0f, Vector3.zero);

			if(g.gameObject)
				Destroy(g.gameObject, 3.0f);
			//CleanupPositions();
		}  

	}

	void CheckDestroyedLetters()
	{
		if( builtWord.Count > 0)
		{
			//foreach(GameObject g in builtWord)
			for(int i = 0; i < builtWord.Count; i++)
			{
				GameObject g = builtWord[i];

				if(g)
				{
					Letra l = g.GetComponent<Letra>();

					if(l)
						if(l.IsDestroyed) 
						{
							
							
							builtWord.Remove(g.gameObject);
							

							if (l.IsCorrect() && myWordType== WordType.misspelledSingle)
								SetWordWrong ();

							Destroy(g.gameObject);
						}
				}
			}
		}

		if (builtWord.Count <= 0) {
			
		}
	}

	void SetWordWrong()
	{
		wordWrong = true;
	}

}

