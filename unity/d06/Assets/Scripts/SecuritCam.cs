using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuritCam : MonoBehaviour {


	public Particule particule;
	public  UiGame uigame;


	void OnTriggerStay () {

		if (particule && uigame && particule.getInparticule()) {
			uigame.addNotice(0.1f);
		} else if (particule && uigame) {
			uigame.addNotice(2f);
		}
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
