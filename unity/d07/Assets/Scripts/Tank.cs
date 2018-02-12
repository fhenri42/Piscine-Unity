using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

	public float	speed;
	private Rigidbody rb;
	public Transform GameCamera;
	private bool boost = true;
	private float boostConteur = 0;
	public int hp = 10;
	private bool isGrounded;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision theCollision) {
		if (theCollision.gameObject.name == "Terrain") { isGrounded = true; }
	}

	void OnCollisionExit(Collision theCollision) {
		if (theCollision.gameObject.name == "Terrain") { isGrounded = false; }
	}

	public void setHp () {
		hp -= 2;
	}
	void Update () {
		if(boostConteur > 2) { boost = false; }
		if(boostConteur < -10) {boostConteur = 0; boost = true; }
		if(!boost) { boostConteur -= Time.deltaTime;}
		if(isGrounded) {

			if (Input.GetKey(KeyCode.LeftShift) && boost) {

				if (Input.GetKey("up") || Input.GetKey("w")) { rb.AddForce(transform.forward *speed * 3); }
				else if (Input.GetKey("down") || Input.GetKey("s")) { rb.AddForce(-transform.forward *speed * 3); }
				boostConteur+= Time.deltaTime;

			} else {
				if (Input.GetKey("up") || Input.GetKey("w")) { rb.AddForce(transform.forward *speed); }
				else if (Input.GetKey("down") || Input.GetKey("s")) { rb.AddForce(-transform.forward *speed); }
			}

			if (Input.GetKey("left")|| Input.GetKey("a")) { transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 2, 0); }
			if (Input.GetKey("right") || Input.GetKey("d")) { transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 2, 0); }

		}

	}

	void LateUpdate() {
		 if(hp < 0) {
			 print("I am Destroy");
		 	Destroy(gameObject);
		 }
	 }
}
