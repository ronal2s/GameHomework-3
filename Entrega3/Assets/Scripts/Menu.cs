using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour {

	public Text usuario, usuarioMenu;
	public GameObject cambiarNombre, canvas, fondo;
	// Use this for initialization
	void Start () {
		usuario.text = PlayerPrefs.GetString ("Usuario");
	}
	


	public void abrirJuego()
	{
		SceneManager.LoadScene ("Game", LoadSceneMode.Additive);
		SceneManager.SetActiveScene (SceneManager.GetSceneByName ("Game"));
		canvas.SetActive (false);
		fondo.SetActive (false);
		Destroy (gameObject);
	}



	public void cambiarUsuario()
	{
		PlayerPrefs.SetString ("Usuario", usuarioMenu.text);
		cambiarNombre.SetActive (false);
		usuario.text = PlayerPrefs.GetString ("Usuario");

	}

	public void salirCambiarNombre()
	{
		cambiarNombre.SetActive (false);
	}

	public void abrirCambiarNombre()
	{
		cambiarNombre.SetActive (true);
	}

	public void salir()
	{
		Application.Quit ();
	}

}
