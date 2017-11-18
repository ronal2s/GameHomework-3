using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	private GameObject player;
	private GameObject global;
	private Global globalScript;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		global = GameObject.Find ("Global");
		globalScript = global.GetComponent<Global> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (globalScript.controlador == Global.ControlJuego.Corriendo) {
			transform.position = new Vector3 (player.transform.position.x + 6f, 0f, -10f);
		//}
	}
}
