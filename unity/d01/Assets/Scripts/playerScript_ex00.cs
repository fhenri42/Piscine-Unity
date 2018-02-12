using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour {

	private bool InAir = false;
	public GameObject Claire = null;
	public GameObject John = null;
	public GameObject Thomas = null;


	public GameObject MassClaire = null;
	public GameObject MassJohn = null;
	public GameObject MassThomas = null;
	float maxSpeed = 10f;
	private int current = 0;


	void OnCollisionEnter2D(Collision2D coll) {


		if (coll.gameObject.tag == "obj") {
			InAir = false;

		}
	}

	void FixedUpdate()
	{
		float move = Input.GetAxis("Horizontal");
		Vector2 movement = new Vector2(move, 0);
		if(current == 0 && Claire != null) {
			Claire.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, Claire.GetComponent<Rigidbody2D>().velocity.y);
			Claire.GetComponent<Rigidbody2D>().AddForce(movement * maxSpeed);
		}
		if(current == 1 && John != null) {
			John.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, John.GetComponent<Rigidbody2D>().velocity.y);
			John.GetComponent<Rigidbody2D>().AddForce(movement * maxSpeed);
		}
		if(current == 2 && Thomas != null) {
			Thomas.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, Thomas.GetComponent<Rigidbody2D>().velocity.y);
			Thomas.GetComponent<Rigidbody2D>().AddForce(movement * maxSpeed);
		}

	}

	void Update () {



		if (Input.GetKey("right")) {
			if (current == 0 && Claire != null) Claire.GetComponent<Rigidbody2D>().AddForce(new Vector3(300, 0,0.0f));
			if (current == 1 && John != null) John.GetComponent<Rigidbody2D>().AddForce(new Vector3(300, 0,0.0f));
			if (current == 2 && Thomas != null) Thomas.GetComponent<Rigidbody2D>().AddForce(new Vector3(300, 0,0.0f));

		}
		if (Input.GetKey("left")) {
			if (current == 0 && Claire != null)	Claire.GetComponent<Rigidbody2D>().AddForce(new Vector3(-300, 0,0.0f));
			if (current == 1 && John != null)	John.GetComponent<Rigidbody2D>().AddForce(new Vector3(-300, 0,0.0f));
			if (current == 2 && Thomas != null)	Thomas.GetComponent<Rigidbody2D>().AddForce(new Vector3(-300, 0,0.0f));
		}

		if (Input.GetKeyDown("space") && InAir == false) {
			if (current == 0 && Claire != null)	{
				InAir = true;
				Claire.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,1000)); }
			if (current == 1 && John != null)	{
				InAir = true;
				John.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,3000)); }
			if (current == 2 && Thomas != null)	{
				InAir = true;
				Thomas.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,2000));
			}
		}

		if (Input.GetKey("1")) {
		MassClaire.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			MassJohn.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			MassThomas.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			current = 0;
		}
		if (Input.GetKey("2")) {
			MassClaire.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			MassJohn.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			MassThomas.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			current = 1;
		}
		if (Input.GetKey("3")) {
			MassClaire.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			MassJohn.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			MassThomas.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			current = 2;
		}


		if (Input.GetKeyDown("backspace")) {
			current = 0;
			InAir = false;
			MassClaire.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX | ~RigidbodyConstraints2D.FreezePositionX  | RigidbodyConstraints2D.FreezeRotation;
				MassJohn.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionX  | RigidbodyConstraints2D.FreezeRotation;
				MassThomas.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionX  | RigidbodyConstraints2D.FreezeRotation;


		}
	}

}
