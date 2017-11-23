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


	public void up()
	{
		//rb.bodyType = RigidbodyType2D.Dynamic;
		transform.localScale += new Vector3 (0, 0.02f, 0);
		transform.localPosition += new Vector3 (0, 0.033f, 0);
		//rb.bodyType = RigidbodyType2D.Kinematic;
	}

	public void down()
	{
		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.AddForce (new Vector2 (20, 0));
		//transform.localPosition += new Vector3 (-0.1f, 0, 0);

	}

	public void reset()
	{
		rb.bodyType = RigidbodyType2D.Static;
		transform.localRotation = new Quaternion (0, 0, 0, 0);
		transform.localScale = new Vector3 (0.1340f, 0.29f, 1f);
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "item") {
			Destroy (col.gameObject);
		}

	}
}
