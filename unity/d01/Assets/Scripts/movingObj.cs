using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObj : MonoBehaviour {

	// Use this for initialization
	public GameObject plateaux = null;

	void Start () {

	}

	void Update () {

		if (plateaux != null) {
			if (plateaux.transform.position.y  < 6) { plateaux.GetComponent<Rigidbody2D>().gravityScale = -0.55f; }
		 if (plateaux.transform.position.y > 2) { plateaux.GetComponent<Rigidbody2D>().gravityScale = 0.55f; }
		}
		}
	}
