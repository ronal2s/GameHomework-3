using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
	public GameObject barra, global;
	private prueba barraScript;
	private Global globalScript;
	// Use this for initialization
	void Start () {
		barraScript = barra.GetComponent<prueba> ();
		globalScript = global.GetComponent<Global> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && globalScript.controlador== Global.ControlJuego.Jugando) {
			barraScript.up ();
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			globalScript.controlador = Global.ControlJuego.AgrandandoRectangulo;
			barraScript.down ();
			//globalScript.controlador = Global.ControlJuego.Parado;
		}
		if (globalScript.controlador == Global.ControlJuego.Parado) {
			barraScript.rb.bodyType = RigidbodyType2D.Kinematic;
		}
	}
}
