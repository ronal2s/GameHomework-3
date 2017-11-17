using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
	public GameObject barra, global;
	private prueba barraScript;
	private Global globalScript;
	private Rigidbody2D rb;
	public float velocidadX;
	public bool movin, salto, suelo;
	// Use this for initialization
	void Start () {
		barraScript = barra.GetComponent<prueba> ();
		globalScript = global.GetComponent<Global> ();
		rb = GetComponent<Rigidbody2D> ();
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
		if (barra.transform.localRotation.z <= -0.70f && !movin) {
			//print ("Quieto");
			mover ();
		}

	}



	void mover()
	{
		velocidadX = 3f;
		rb.velocity = new Vector2 (velocidadX, rb.velocity.y);
		globalScript.controlador = Global.ControlJuego.Corriendo;

	}

	void stopMover()
	{
		velocidadX = 0;
		rb.bodyType = RigidbodyType2D.Static;
		barraScript.reset ();
		barra.transform.localPosition = new Vector3 (transform.position.x, -1.99f);
		barra.transform.position = new Vector3 (gameObject.transform.position.x + 1f, barra.transform.position.y);
		globalScript.controlador = Global.ControlJuego.Jugando;
		rb.bodyType = RigidbodyType2D.Dynamic;
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Palo" && !salto) {
			salto = true;
			gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y + 0.2f);
		}
		if (col.gameObject.tag == "suelo" && salto) {
			salto= false;
			stopMover ();
		}

	}
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Palo" && suelo) {
			stopMover();
		}
	}
}
