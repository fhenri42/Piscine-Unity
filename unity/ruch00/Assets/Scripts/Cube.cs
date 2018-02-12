using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	void Start () {

	}

	public string letter;

	void Update () {
		transform.Translate(0.0F, Random.Range(-0.15F, -0.1F), 0);

		if (letter == "A" && Input.GetKeyDown("a")) {
			float y = transform.position.y;
			double pres =   - 1.83 - y;
			if (pres < 0) { pres *=-1; }
			Debug.Log("Precision: " + pres);
			GameObject.Destroy(this.gameObject);
		}

		if (letter == "S" && Input.GetKeyDown("s")) {
			float y = transform.position.y;
			double pres =  - 1.83 - y;
			if (pres < 0) { pres *=-1; }
			Debug.Log("Precision: " + pres);
			GameObject.Destroy(this.gameObject);

		}

		if (letter == "D" && Input.GetKeyDown("d")) {
			float y = transform.position.y;
			double pres =  - 1.83 - y;
			if (pres < 0) { pres *=-1; }
			Debug.Log("Precision: " + pres );
			GameObject.Destroy(this.gameObject);

		}
		if(transform.position.y < -4.17) { GameObject.Destroy(this.gameObject); }

	}
}
