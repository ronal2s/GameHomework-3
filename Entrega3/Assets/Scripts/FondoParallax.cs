using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoParallax : MonoBehaviour {

    public float VelocidadX = 1f;
    MeshRenderer renderizador;

	// Use this for initialization
	void Start () {
        renderizador = GetComponent<MeshRenderer>();
		
	}
	// Update is called once per frame
	void Update () {
        renderizador.material.mainTextureOffset = new Vector2(Time.time * VelocidadX, 0);
		
	}
}
