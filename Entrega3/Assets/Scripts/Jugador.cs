using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
	public GameObject barra, global;
	private prueba barraScript;
	private Global globalScript;
	private Rigidbody2D rb;
	private Animator anim;
	public float velocidadX;
	public bool movin, salto, suelo;
	// Use this for initialization
	void Start () {
		barraScript = barra.GetComponent<prueba> ();
		globalScript = global.GetComponent<Global> ();
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
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
			mover2 ();
			//barra.transform.localRotation = new Quaternion (-0.70f,0,0,0);

		}
		if (barra.transform.position.y < -4f) {
			perder ();
		}
	}



	void mover()
	{
		velocidadX = 5f;
		rb.velocity = new Vector2 (velocidadX, rb.velocity.y);
		anim.SetBool("run", true);
		globalScript.controlador = Global.ControlJuego.Corriendo;

	}
	float velocidadInicialY, velocidadActualY, aceleracion = 0;

	void mover2()
	{
		aceleracion = 2;
		velocidadActualY += aceleracion * Time.deltaTime;
		gameObject.transform.Translate(new Vector3(velocidadActualY * Time.deltaTime + aceleracion * Mathf.Pow(Time.deltaTime, 2) / 2, 0));
		velocidadInicialY = velocidadActualY;
		anim.SetBool("run", true);
		globalScript.controlador = Global.ControlJuego.Corriendo;

	}

	void stopMover()
	{
		velocidadX = 0;
		aceleracion = 0;
		velocidadActualY = 0;
		rb.bodyType = RigidbodyType2D.Static;
		anim.SetBool("run", false);
		//Poner la cámara donde el jugador
		Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 1, 0, -10f);

		//gameObject.transform.position -= new Vector3 (1f, 0);
		barraScript.reset ();
		barra.transform.localPosition = new Vector3 (transform.position.x, -2.52f);
		barra.transform.position = new Vector3 (gameObject.transform.position.x + 0.6f, barra.transform.position.y);
		globalScript.controlador = Global.ControlJuego.Jugando;
		rb.bodyType = RigidbodyType2D.Dynamic;

		//Poner la cámara donde el jugador
		//Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + 1, 0, -10f);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Palo" && !salto) {
			salto = true;
			gameObject.transform.position = new Vector3 (transform.position.x, transform.position.y + 0.2f);
		}
		if (col.gameObject.tag == "suelo" && salto) {
			salto= false;
			Global.puntos++;
			stopMover ();
		}
		if (col.gameObject.name == "Perder") {
			perder ();
		}

	}

	void perder()
	{
		globalScript.perder ();
		//gameObject.transform.position = new Vector3 (-7, -2.45f);
		gameObject.transform.position = GameObject.Find("BloqueA0(Clone)").transform.position;
		gameObject.transform.position = new Vector3 (transform.position.x - 0.1f, -2.45f);
		stopMover ();

	}
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Palo" && suelo) {
			stopMover();
			velocidadX = 0;
		}
	}
}
