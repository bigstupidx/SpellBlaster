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


	void Awake()
	{
		positions = gameObject.GetComponentsInChildren<LetterPosition>();
		CleanupPositions();
	}

	void Update()
	{
		

	}

	public List<GameObject> builtWord;

	public LetterPosition[] positions;

	public void SetWordInPlay(string Value)
	{
		wordInPlay = Value;

		builtWord.Clear();
		foreach(char ch in wordInPlay)
		{
			
			switch(ch)
			{
				case 'A':
						builtWord.Add(A_Mayuscula_Prefab);
						break;
				case 'B':
						builtWord.Add(B_Mayuscula_Prefab);
						break;
				case 'C':
						builtWord.Add(C_Mayuscula_Prefab);
						break;
				case 'D':
						builtWord.Add(D_Mayuscula_Prefab);
						break;
				case 'E':
						builtWord.Add(E_Mayuscula_Prefab);
						break;
				case 'F':
						builtWord.Add(F_Mayuscula_Prefab);
						break;
				case 'G':
						builtWord.Add(G_Mayuscula_Prefab);
						break;
				case 'H':
						builtWord.Add(H_Mayuscula_Prefab);
						break;
				case 'I':
						builtWord.Add(I_Mayuscula_Prefab);
						break;
				case 'J':
						builtWord.Add(J_Mayuscula_Prefab);
						break;
				case 'K':
						builtWord.Add(K_Mayuscula_Prefab);
						break;
				case 'L':
						builtWord.Add(L_Mayuscula_Prefab);
						break;
				case 'M':
						builtWord.Add(M_Mayuscula_Prefab);
						break;
				case 'N':
						builtWord.Add(N_Mayuscula_Prefab);
						break;
				case 'O':
						builtWord.Add(O_Mayuscula_Prefab);
						break;
				case 'P':
						builtWord.Add(P_Mayuscula_Prefab);
						break;
				case 'Q':
						builtWord.Add(Q_Mayuscula_Prefab);
						break;
				case 'R':
						builtWord.Add(R_Mayuscula_Prefab);
						break;
				case 'S':
						builtWord.Add(S_Mayuscula_Prefab);
						break;
				case 'T':
						builtWord.Add(T_Mayuscula_Prefab);
						break;
				case 'U':
						builtWord.Add(U_Mayuscula_Prefab);
						break;
				case 'V':
						builtWord.Add(V_Mayuscula_Prefab);
						break;
				case 'W':
						builtWord.Add(W_Mayuscula_Prefab);
						break;
				case 'X':
						builtWord.Add(X_Mayuscula_Prefab);
						break;
				case 'Y':
						builtWord.Add(Y_Mayuscula_Prefab);
						break;
				case 'Z':
						builtWord.Add(Z_Mayuscula_Prefab);
						break;




				case 'a':
						builtWord.Add(a_Minuscula_Prefab);
						break;
				case 'b':
						builtWord.Add(b_Minuscula_Prefab);
						break;
				case 'c':
						builtWord.Add(c_Minuscula_Prefab);
						break;
				case 'd':
						builtWord.Add(d_Minuscula_Prefab);
						break;
				case 'e':
						builtWord.Add(e_Minuscula_Prefab);
						break;
				case 'f':
						builtWord.Add(f_Minuscula_Prefab);
						break;
				case 'g':
						builtWord.Add(g_Minuscula_Prefab);
						break;
				case 'h':
						builtWord.Add(h_Minuscula_Prefab);
						break;
				case 'i':
						builtWord.Add(i_Minuscula_Prefab);
						break;
				case 'j':
						builtWord.Add(j_Minuscula_Prefab);
						break;
				case 'k':
						builtWord.Add(k_Minuscula_Prefab);
						break;
				case 'l':
						builtWord.Add(l_Minuscula_Prefab);
						break;
				case 'm':
						builtWord.Add(m_Minuscula_Prefab);
						break;
				case 'n':
						builtWord.Add(n_Minuscula_Prefab);
						break;
				case 'o':
						builtWord.Add(o_Minuscula_Prefab);
						break;
				case 'p':
						builtWord.Add(p_Minuscula_Prefab);
						break;
				case 'q':
						builtWord.Add(q_Minuscula_Prefab);
						break;
				case 'r':
						builtWord.Add(r_Minuscula_Prefab);
						break;
				case 's':
						builtWord.Add(s_Minuscula_Prefab);
						break;
				case 't':
						builtWord.Add(t_Minuscula_Prefab);
						break;
				case 'u':
						builtWord.Add(u_Minuscula_Prefab);
						break;
				case 'v':
						builtWord.Add(v_Minuscula_Prefab);
						break;
				case 'w':
						builtWord.Add(w_Minuscula_Prefab);
						break;
				case 'x':
						builtWord.Add(x_Minuscula_Prefab);
						break;
				case 'y':
						builtWord.Add(y_Minuscula_Prefab);
						break;
				case 'z':
						builtWord.Add(z_Minuscula_Prefab);
						break;



				default:
						builtWord.Add(J_Mayuscula_Prefab);
					break;
			}

		}

		int i = 0;
		foreach(GameObject letter in builtWord)
		{
			Instantiate(letter, letter.transform.position, letter.transform.rotation, positions[i].transform);
			i++;
		}

	}


	void CleanupPositions()
	{
		foreach(LetterPosition lp in positions)
		{
			GameObject l = lp.transform.GetComponentInChildren<Letra>().gameObject;


			if(l) Destroy(l);
		}
	}



}
