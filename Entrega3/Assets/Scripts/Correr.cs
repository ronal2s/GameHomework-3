using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correr : MonoBehaviour {

	public float velocidadInicialY, velocidadActualY;


	// Use this for initialization
	void Start () {
		//velocidadInicialY = 0;
		//Destroy(gameObject,3);
	}

	// Update is called once per frame
	void Update () {
		//Dejarlo caer con fisica real
		velocidadActualY += Physics.gravity.y * Time.deltaTime;
		gameObject.transform.Translate(new Vector3(velocidadActualY * Time.deltaTime + Physics.gravity.y * Mathf.Pow(Time.deltaTime, 2) / 2, 0));
		velocidadInicialY = velocidadActualY;
	}
}
