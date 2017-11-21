using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
	public GameObject meteoro, posMeteoro, gameover;
	private GameObject aux;
	public ControlJuego controlador;
	public bool game;
	// Use this for initialization
	void Start () {
		if (game) {
			controlador = ControlJuego.Jugando;
			textUsuario.text = PlayerPrefs.GetString ("Usuario");
		}
		StartCoroutine (meteorito ());

	}
	
	// Update is called once per frame
	void Update () {
		if (game) {
			textPuntos.text = "Puntos: " + puntos.ToString();	

		}
	}

	IEnumerator meteorito()
	{
		while (true) {
			aux = Instantiate (meteoro);
			aux.transform.position = new Vector3 (posMeteoro.transform.position.x, posMeteoro.transform.position.y);
			posMeteoro.transform.position = new Vector3 (Random.Range (-8.55f, Camera.main.transform.position.x + 5), posMeteoro.transform.position.y);
			yield return new WaitForSeconds (3);
			if (!game) {
				aux = Instantiate (meteoro);
				aux.transform.position = new Vector3 (posMeteoro.transform.position.x, posMeteoro.transform.position.y);
				posMeteoro.transform.position = new Vector3 (Random.Range (-7f, Camera.main.transform.position.x + 2), posMeteoro.transform.position.y);
				yield return new WaitForSeconds (1);

			}
		}
	}

	public void salirJuego()
	{
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}

	public void perder()
	{
		gameover.SetActive (true);
	}

	public void reintentar()
	{
		//SceneManager.LoadScene ("Game",LoadSceneMode.Single);
		puntos = 0;
		gameover.SetActive (false);
	}
}
