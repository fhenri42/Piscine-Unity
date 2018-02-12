using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lights : MonoBehaviour {

	// Use this for initialization
	public  UiGame uigame;


void OnTriggerStay () {

	print("IN STAY");
	if(uigame) {
		uigame.addNotice(1f);
	}
}
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
