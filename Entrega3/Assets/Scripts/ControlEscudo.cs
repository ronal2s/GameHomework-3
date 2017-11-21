using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEscudo : MonoBehaviour {
    const float ACELERACIONX = 0f;
    const float ACELERACIONY = 0f;
    const float VELOCIDADINICIALX = 0.01f;
    const float VELOCIDADINICIALY = 0.01f;
    Transform centro;
    float radio = 10f;
    Vector2 angulo;
    Vector3 nuevaPosicion;
    Vector3 velocidadFinal = Vector3.zero;
    float tiempoDisparo;
	public GameObject padre;
	// Use this for initialization
	void Start () {
		Disparar (padre.transform, 0.5f);	
		gameObject.transform.position = new Vector3 (gameObject.transform.position.x, transform.position.y, -2.18f);
	}

    public void Disparar(Transform Centro, float Radio = 10f, float velocidadInicialX = VELOCIDADINICIALX, float velocidadInicialY = VELOCIDADINICIALY)
    {
        centro = Centro;
        radio = Radio;
        velocidadFinal = new Vector3(velocidadInicialX, velocidadInicialY);
        tiempoDisparo = Time.time;

    }

	
	// Update is called once per frame
	void Update () {

        velocidadFinal += new Vector3(ACELERACIONX * Time.deltaTime,
                                      ACELERACIONY * Time.deltaTime);
        
        angulo = new Vector2(velocidadFinal.x * (Time.time - tiempoDisparo) / radio, velocidadFinal.y * (Time.time - tiempoDisparo) / radio);


        nuevaPosicion = new Vector3(centro.position.x + radio * Mathf.Cos(angulo.x),
                                    centro.position.y + radio * Mathf.Sin(angulo.y), -2.18f);
        //al final:
        gameObject.transform.position = nuevaPosicion;
	}
}
