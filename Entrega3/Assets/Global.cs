using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour {
	public enum ControlJuego
	{
		Jugando,
		Corriendo,
		AgrandandoRectangulo,
		Parado
	};

	public static int puntos=0;
	public Text textPuntos, textUsuario;
	public GameObject meteoro, posMeteoro;
	private GameObject aux;
	public ControlJuego controlador;
	// Use this for initialization
	void Start () {
		controlador = ControlJuego.Jugando;
		StartCoroutine (meteorito ());
		textUsuario.text = PlayerPrefs.GetString ("Usuario");
	}
	
	// Update is called once per frame
	void Update () {
		textPuntos.text = "Puntos: " + puntos.ToString();	
	}

	IEnumerator meteorito()
	{
		while (true) {
			aux = Instantiate (meteoro);
			aux.transform.position = new Vector3 (posMeteoro.transform.position.x, posMeteoro.transform.position.y);
			posMeteoro.transform.position = new Vector3 (Random.Range (-8.55f, Camera.main.transform.position.x + 10), posMeteoro.transform.position.y);
			yield return new WaitForSeconds (3);
		}
	}

}
