using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public Player	player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		if (!player)
			return ;
		transform.Translate((player.transform.position.x - transform.position.x) / 5, (player.transform.position.y - transform.position.y) / 5, 0);
	}
}
