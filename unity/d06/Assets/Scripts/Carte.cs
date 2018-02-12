using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carte : MonoBehaviour {

	// Use this for initialization
	private bool haveKey = false;

	void OnTriggerEnter (Collider obj) { if(obj.gameObject.name == "player") {

			haveKey = true;
			  gameObject.SetActive(false);
		 } }
	public bool getHaveKey() { return haveKey; }

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
