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

		if(destroyWord || wordManager.builtWord.Count <= 0 || wordManager.wordWrong)
		{
			wordManager.DestroyWordInPlay();

			destroyWord = false;



			SeleccionarPalabra();
		}


	}

	IList<XElement>  rows;
	void InicializarDiccionario()
	{

		CargarConfiguracion();

		TextAsset ta = Resources.Load("wd") as TextAsset;

		XDocument xDoc = XDocument.Parse(ta.text);

		rows = xDoc.Descendants().Where(
			d => d.Name == "Palabra"
			&& d.Descendants().Any(e => (e.Name == "Dificultad" && e.Value == Config_Dificutad))
			&& d.Descendants().Any(e => (e.Name == "Idioma" && e.Value == Config_Idioma))
		).ToList();


	}	

	string Config_Dificutad;
	string Config_Idioma;

	void CargarConfiguracion()
	{

		

		switch (DificultadSeleccionada) {
			
		case SelectionManager.Dificultad.Facil:
			Config_Dificutad = "1";
			break;

		case SelectionManager.Dificultad.Medio:
			Config_Dificutad = "2";
			break;

		case SelectionManager.Dificultad.Dificil:
			Config_Dificutad = "3";
			break;

		default:
			Config_Dificutad = "2";
			break;

		}



		switch (IdiomaSeleccionado) {

		case SelectionManager.Idioma.es_MX:
			Config_Idioma = "es-MX";
			break;

		case SelectionManager.Idioma.en_US:
			Config_Idioma = "en-US";
			break;

		default:
			Config_Idioma = "en-US";
			break;

		}

	}

	int puntos;
	public void SeleccionarPalabra()
	{
	


		int i = UnityEngine.Random.Range (0, rows.Count ());

		//Debug.Log("Selected word index = " + i);

		XElement xEle = rows[i];	

		StringBuilder output = new StringBuilder();
		int posicionIncorrecta = 0;


		foreach (XElement elemnt in xEle.Descendants().Where( e => e.Name == "Nombre"))
		{
			output.Append(elemnt.Value);
		}

		foreach (XElement elemnt in xEle.Descendants().Where( e => e.Name == "Posicion"))
		{
			posicionIncorrecta = Convert.ToInt32 (elemnt.Value);
		}

		foreach (XElement elemnt in xEle.Descendants().Where( e => e.Name == "Puntos"))
		{
			puntos = Convert.ToInt32 (elemnt.Value);
		}

		Debug.Log("Selected word: " + output.ToString());


		wordManager.SetWordInPlay(output.ToString(), posicionIncorrecta);

	}


}
