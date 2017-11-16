using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour {

	public Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.bodyType = RigidbodyType2D.Kinematic;
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void up()
	{
		rb.bodyType = RigidbodyType2D.Dynamic;
		transform.localScale += new Vector3 (0, 0.1f, 0);
		transform.localPosition += new Vector3 (0, 0.18f, 0);
		//rb.bodyType = RigidbodyType2D.Kinematic;
	}

	public void down()
	{
		rb.AddForce (new Vector2 (10, 0));

	}
}
