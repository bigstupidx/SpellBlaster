using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.Xml;
using System.IO;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		InicializarDiccionario ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	void InicializarDiccionario()
	{
		
		StringBuilder output = new StringBuilder();

		String xmlString = System.IO.File.ReadAllText(@"Assets\Dict\wd");


		// Create an XmlReader
		using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
		{
			reader.ReadToFollowing("Palabra");
			reader.MoveToAttribute("Dificultad");
			string dificultad = reader.Value;
			output.AppendLine("Dificultad: " + dificultad);

			reader.ReadToFollowing("Titulo");
			output.AppendLine("Palabra: " + reader.ReadElementContentAsString());
		}

		Debug.Log (output.ToString());

	}


}
