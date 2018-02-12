using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
	public BoxCollider2D bc;

	public	Vector3		initPos;

	void Awake() {
        bc = GetComponent<BoxCollider2D>();
		initPos = bc.bounds.center;
    }

	void Update () {
		
	}
}
