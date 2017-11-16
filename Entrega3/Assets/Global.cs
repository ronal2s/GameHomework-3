using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {
	public enum ControlJuego
	{
		Jugando,
		Corriendo,
		AgrandandoRectangulo,
		Parado
	};
	public ControlJuego controlador;
	// Use this for initialization
	void Start () {
		controlador = ControlJuego.Jugando;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
