using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerScript_ex02 : MonoBehaviour {


		private bool InAir = false;

		void Start () {

		}
		public GameObject Claire = null;
		public GameObject John = null;
		public GameObject Thomas = null;


		public GameObject MassClaire = null;
		public GameObject MassJohn = null;
		public GameObject MassThomas = null;

		//	public Collider2D objectCollider;
		public Collider2D blueExit;
		public Collider2D redExit;
		public Collider2D yellowExit;

		public Collider2D tpIn;
		public Collider2D button1;
		public Collider2D dor1;

		public Collider2D button2;
		public Collider2D dor2;

		float maxSpeed = 10f;
		float maxSpeed1 = 5f;
		float maxSpeed2 = 2f;
		private int current = 0;


		void OnCollisionEnter2D(Collision2D coll) {


			if (coll.gameObject.tag == "obj") { InAir = false; }
		}

		void FixedUpdate()
		{
			float move = Input.GetAxis("Horizontal");
			Vector2 movement = new Vector2(move, 0);
			if(current == 0 && Claire != null) {
				Claire.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed2, Claire.GetComponent<Rigidbody2D>().velocity.y);
				Claire.GetComponent<Rigidbody2D>().AddForce(movement * maxSpeed);
			}
			if(current == 1 && John != null) {
				John.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, John.GetComponent<Rigidbody2D>().velocity.y);
				John.GetComponent<Rigidbody2D>().AddForce(movement * maxSpeed);
			}
			if(current == 2 && Thomas != null) {
				Thomas.GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed1, Thomas.GetComponent<Rigidbody2D>().velocity.y);
				Thomas.GetComponent<Rigidbody2D>().AddForce(movement * maxSpeed);
			}

		}

		void Update () {

			if (Input.GetKey("right")) {
				if (current == 0 && Claire != null) Claire.GetComponent<Rigidbody2D>().AddForce(new Vector3(100, 0,0.0f));
				if (current == 1 && John != null) John.GetComponent<Rigidbody2D>().AddForce(new Vector3(300, 0,0.0f));
				if (current == 2 && Thomas != null) Thomas.GetComponent<Rigidbody2D>().AddForce(new Vector3(200, 0,0.0f));

			}
			if (Input.GetKey("left")) {
				if (current == 0 && Claire != null)	Claire.GetComponent<Rigidbody2D>().AddForce(new Vector3(-100, 0,0.0f));
				if (current == 1 && John != null)	John.GetComponent<Rigidbody2D>().AddForce(new Vector3(-300, 0,0.0f));
				if (current == 2 && Thomas != null)	Thomas.GetComponent<Rigidbody2D>().AddForce(new Vector3(-200, 0,0.0f));
			}
			if (Input.GetKeyDown("space") && InAir == false) {
				if (current == 0 && Claire != null)	{
					InAir = true;
					Claire.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,3300)); }
					if (current == 1 && John != null)	{
						InAir = true;
						John.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,5000)); }
						if (current == 2 && Thomas != null)	{
							InAir = true;
							Thomas.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,4000));
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
					if (MassClaire.GetComponent<Collider2D>().IsTouching(blueExit) &&  MassJohn.GetComponent<Collider2D>().IsTouching(yellowExit) &&  MassThomas.GetComponent<Collider2D>().IsTouching(redExit)) {
						 Scene scene = SceneManager.GetActiveScene();
						 if (scene.name == "ex02") {
							 SceneManager.LoadScene("Scenes/lvl2_ex02", LoadSceneMode.Single);
						 } else if (scene.name == "lvl2_ex02") {
							 SceneManager.LoadScene("Scenes/lvl3_ex03", LoadSceneMode.Single);
						 } else if (scene.name == "lvl3_ex03") {
							 SceneManager.LoadScene("Scenes/lvl4_ex04", LoadSceneMode.Single);
						 }
						 else if (scene.name == "lvl4_ex04") {
							 print("END OF GAME");
						 }

					}

					if (tpIn != null  && MassClaire.GetComponent<Collider2D>().IsTouching(tpIn)) {
						MassClaire.transform.position = new Vector2(7.17f, -3.74f);
					}

					 if(tpIn != null && MassJohn.GetComponent<Collider2D>().IsTouching(tpIn)) {
					MassJohn.transform.position = new Vector2(7.17f, -3.74f);

					 }

					if (tpIn != null && MassThomas.GetComponent<Collider2D>().IsTouching(tpIn)) {
						MassThomas.transform.position = new Vector2(7.17f, -3.74f);
					}

					if(button1 != null && MassJohn.GetComponent<Collider2D>().IsTouching(button1)) {
						dor1.transform.Rotate( new Vector3(0,0,1));
					}

					if (button2 != null && MassThomas.GetComponent<Collider2D>().IsTouching(button2)) {
						dor2.transform.Translate( new Vector3(0,10,0));
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
