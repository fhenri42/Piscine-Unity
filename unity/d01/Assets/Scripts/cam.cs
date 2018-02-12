using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour {

	// Use this for initialization
	public GameObject Claire;
	public GameObject John;
	public GameObject Thomas;
	public int current;

	private Vector3 offset;

	private Vector3 startClaire;
	private Vector3 startJohn;
	private Vector3 startThomas;


	void Start () {

		offset = transform.position - Claire.transform.position;
		startClaire = Claire.transform.position;
		startJohn = John.transform.position;
		startThomas = Thomas.transform.position;
	}
//
	// Update is called once per frame
	void Update () {


		if (Input.GetKey("1")) { current = 0; }
		if (Input.GetKey("2")) { current = 1; }
		if (Input.GetKey("3")) { current = 2; }

		if (current == 0) {  transform.position = Claire.transform.position + offset;}
		if (current == 1) {  transform.position = John.transform.position + offset;; }
		if (current == 2) {  transform.position = Thomas.transform.position + offset; }

		if (Input.GetKeyDown("backspace")) {
			Claire.transform.position = startClaire;
			John.transform.position = startJohn;
			Thomas.transform.position = startThomas;
			current = 0;
		}
	}

}
