using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	// Use this for initialization
	public Carte carte;


	void OnTriggerEnter (Collider obj) {

		if(obj.gameObject.name == "player" && carte.getHaveKey()) {
			Vector3 tmp = new Vector3(34f,-0.33f,15.06f);
			transform.position = tmp;
		 }
	 }
	 void OnTriggerExit (Collider obj) {

		 if(obj.gameObject.name == "player") {
			 Vector3 tmp = new Vector3(30f,-0.33f,15.06f);
			 transform.position = tmp;
			}
		}


	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
