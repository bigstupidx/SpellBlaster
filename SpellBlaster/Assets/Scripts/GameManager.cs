using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Linq;


public class GameManager : MonoBehaviour 
{

	public enum Idioma {
		en_US, es_MX
	};

	public enum Dificultad {
		Facil, Medio, Dificil
	};
		
	public Idioma IdiomaSeleccionado;
	public Dificultad DificultadSeleccionada;
	public WordManager wordManager;



	// Use this for initialization
	void Start () {
	

		gameStarted = false;

	}
	
	// Update is called once per frame

	float timeSinceStart;
	bool gameStarted;

	void Update () {
	
		timeSinceStart += Time.deltaTime;

		if (timeSinceStart > 3.0f && !gameStarted) {
		
			InicializarDiccionario ();
			SeleccionarPalabra ();
			gameStarted = true;
		}
			


	}



	IList<XElement>  rows;
	void InicializarDiccionario()
	{

		string str_dificultad;

		switch (DificultadSeleccionada) {
			
		case Dificultad.Facil:
			str_dificultad = "1";
			break;

		case Dificultad.Medio:
			str_dificultad = "2";
			break;

		case Dificultad.Dificil:
			str_dificultad = "3";
			break;

		default:
			str_dificultad = "2";
			break;

		}


		string str_idioma;

		switch (IdiomaSeleccionado) {

		case Idioma.es_MX:
			str_idioma = "es-MX";
			break;

		case Idioma.en_US:
			str_idioma = "en-US";
			break;

		default:
			str_idioma = "en-US";
			break;

		}
			
		XDocument xDoc = XDocument.Load(@"Assets/Dict/wd");

		rows = xDoc.Descendants().Where(
			d => d.Name == "Palabra"
			&& d.Descendants().Any(e => (e.Name == "Dificultad" && e.Value == str_dificultad))
			&& d.Descendants().Any(e => (e.Name == "Idioma" && e.Value == str_idioma))
		).ToList();


	}	

	void SeleccionarPalabra()
	{
	
		StringBuilder output = new StringBuilder();

		int i = UnityEngine.Random.Range (0, rows.Count ());

		Debug.Log("Selected word index = " + i);

		XElement xEle = rows[i];	
		foreach (XElement elemnt in xEle.Descendants().Where( e => e.Name == "Nombre"))
		{
			output.Append(elemnt.Value);
		}


		wordManager.SetWordInPlay(output.ToString());

	}


}
