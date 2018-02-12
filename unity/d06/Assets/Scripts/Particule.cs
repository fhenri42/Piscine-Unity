using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particule : MonoBehaviour {

	// Use this for initialization
	public bool inParticule = false;
	void OnTriggerEnter (Collider obj) {

		if(obj.gameObject.name == "player") {

			print("in particule");
			inParticule = true; } }
	void OnTriggerExit (Collider obj) { if(obj.gameObject.name == "player") { inParticule = false; } }

	public bool getInparticule() { return inParticule; }
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
