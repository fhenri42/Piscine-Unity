using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public float	speed;
	private Rigidbody rb;
	public Transform GameCamera;
	public UiGame uigame;
	public GameObject alarm;
	public Particule particule;


	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update () {

		var CharacterRotation = GameCamera.transform.rotation;
		CharacterRotation.x = 0;
		CharacterRotation.z = 0;

		transform.rotation = CharacterRotation;

 if(Input.GetKey(KeyCode.LeftShift)) {

		if (Input.GetKey("up") || Input.GetKey("w")) {
			rb.AddForce(transform.forward *speed * 5);
			uigame.addNotice(0.4f);
			}
		else if (Input.GetKey("down") || Input.GetKey("s")) {
			rb.AddForce(-transform.forward *speed * 5);
			uigame.addNotice(0.4f);
		}
		else if (Input.GetKey("left")|| Input.GetKey("a")) {
			 rb.AddForce(-transform.right *speed * 5);
			 uigame.addNotice(0.4f);
		 }
		else if (Input.GetKey("right") || Input.GetKey("d")) {
			rb.AddForce(transform.right *speed * 5);
			uigame.addNotice(0.4f);
		}
	} else {
		if (Input.GetKey("up") || Input.GetKey("w")) {
			rb.AddForce(transform.forward *speed);
			}
		else if (Input.GetKey("down") || Input.GetKey("s")) {
			rb.AddForce(-transform.forward *speed);
		}
		else if (Input.GetKey("left")|| Input.GetKey("a")) {
			 rb.AddForce(-transform.right *speed);

		 }
		else if (Input.GetKey("right") || Input.GetKey("d")) {
			rb.AddForce(transform.right *speed);
		}
		 if (uigame.getCurent()  > 0 && !particule.getInparticule() ) {
			uigame.addNotice(-0.4f);

		}
	}

	}
}
