using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {


	public float pow = 0;
	public float time = 0;
	private bool startSpeed = false;
	private bool notEnd = true;
	private string direction = "N";
	public int score = -15;

	void Update () {

		if (notEnd) {

			if (Input.GetKeyDown("space")) { time = Time.time; }
			if (Input.GetKeyUp("space")) {
				pow = Time.time - time;

				startSpeed = true;
			}
			if (startSpeed == true) {

				if (direction == "N") { transform.Translate(0, 5 * pow, 0); }
				if (direction == "S") { transform.Translate(0, -(5 * pow), 0); }
				if (transform.position.y <= 3.5 && transform.position.y >= 2.5 && pow < 0.2f) {
					Debug.Log("In the holl, you have the score of: " + score);
				transform.Translate(100, -100, 0);
				notEnd = false;
				}
				pow -= 0.1f;

				if (pow <= 0) {
					startSpeed = false;
					if (notEnd) { score += 5; Debug.Log("Score:"+score); }
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
