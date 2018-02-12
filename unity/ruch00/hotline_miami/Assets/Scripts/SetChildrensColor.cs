using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChildrensColor : MonoBehaviour {

	public Color		color;

	// Use this for initialization
	void Start () {
		foreach(SpriteRenderer  sr in GetComponentsInChildren<SpriteRenderer> ()) {
			sr.color = color;
		}
	}
}
