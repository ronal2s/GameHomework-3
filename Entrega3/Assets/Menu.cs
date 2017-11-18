using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu : MonoBehaviour {

	public Text usuario, usuarioMenu;
	public GameObject cambiarNombre;
	// Use this for initialization
	void Start () {
		usuario.text = PlayerPrefs.GetString ("Usuario");
	}
	


	public void abrirJuego()
	{
		SceneManager.LoadScene ("Game");
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
