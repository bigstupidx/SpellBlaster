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
	
	public SelectionManager.Idioma IdiomaSeleccionado;
	public SelectionManager.Dificultad DificultadSeleccionada;
	public SelectionManager.Musica TocarMusica;
	public SelectionManager.Efectos TocarEfectos;

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


		if(gameStarted)
		{
			CheckForWord();

		}


	}

	public bool destroyWord;

	void CheckForWord()
	{

		if(destroyWord || wordManager.builtWord.Count <= 0)
		{
			wordManager.DestroyWordInPlay();
			destroyWord = false;

			SeleccionarPalabra();
		}


	}

	IList<XElement>  rows;
	void InicializarDiccionario()
	{

		string str_dificultad;

		switch (DificultadSeleccionada) {
			
		case SelectionManager.Dificultad.Facil:
			str_dificultad = "1";
			break;

		case SelectionManager.Dificultad.Medio:
			str_dificultad = "2";
			break;

		case SelectionManager.Dificultad.Dificil:
			str_dificultad = "3";
			break;

		default:
			str_dificultad = "2";
			break;

		}


		string str_idioma;

		switch (IdiomaSeleccionado) {

		case SelectionManager.Idioma.es_MX:
			str_idioma = "es-MX";
			break;

		case SelectionManager.Idioma.en_US:
			str_idioma = "en-US";
			break;

		default:
			str_idioma = "en-US";
			break;

		}

		TextAsset ta = Resources.Load("wd") as TextAsset;



		XDocument xDoc = XDocument.Parse(ta.text);

		rows = xDoc.Descendants().Where(
			d => d.Name == "Palabra"
			&& d.Descendants().Any(e => (e.Name == "Dificultad" && e.Value == str_dificultad))
			&& d.Descendants().Any(e => (e.Name == "Idioma" && e.Value == str_idioma))
		).ToList();


	}	

	public void SeleccionarPalabra()
	{
	
		StringBuilder output = new StringBuilder();

		int i = UnityEngine.Random.Range (0, rows.Count ());

		//Debug.Log("Selected word index = " + i);

		XElement xEle = rows[i];	
		foreach (XElement elemnt in xEle.Descendants().Where( e => e.Name == "Nombre"))
		{
			output.Append(elemnt.Value);
		}

		Debug.Log("Selected word: " + output.ToString());


		wordManager.SetWordInPlay(output.ToString());

	}


}
