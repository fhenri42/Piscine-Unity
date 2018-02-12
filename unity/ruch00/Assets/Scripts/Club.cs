using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {


	public float pow = 0;
	public float time = 0;
	private bool startSpeed = false;
	private bool notEnd = true;
	private bool firstTime = true;
	private bool atleast = false;
	public GameObject ball;

	private string direction = "N";

	void Start () {

	}
	void Update () {

		if (notEnd) {

			if (Input.GetKeyDown("space")) {
				time = Time.time;
				 if (direction == "N") { transform.Translate(0,-4, 0); }
				 if (direction == "S") { transform.Translate(0,4, 0); }
			}
			if (Input.GetKeyUp("space")) {
				pow = Time.time - time;
				startSpeed = true;

				 if (direction == "N") { transform.Translate(0,4, 0); }
				 if (direction == "S") { transform.Translate(0,-4, 0); }
			}
			if (startSpeed == true) {
				 if (direction == "N") { transform.Translate(0, 5 * pow, 0); }
 				if (direction == "S") { transform.Translate(0, -(5 * pow), 0); }
		 if (ball.transform.position.y <= 3.5 -100 && ball.transform.position.y >= 2.5 -100 && pow < 0.2f) { notEnd = false; }

				pow -= 0.1f;
				if (pow <= 0) {

					startSpeed = false;
				}
			}
			if (transform.position.y > 6) {
				direction = "S";
			}

			if (transform.position.y < -3) {
				direction = "N";
			}
			if (transform.position.y > 3.833 && startSpeed == false) {
				direction = "S";
			}
			if (transform.position.y < 2.307481 && startSpeed == false) {
				direction = "N";
			}
		}
	}
}
