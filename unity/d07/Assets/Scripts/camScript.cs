using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
	public GameObject FirePoint;

	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;
	public float damping = 1;

	void Start () {
		offset = transform.position - player.transform.position;
		offset = new Vector3(8,2,-2);
	}

	void Update () {

		if(player) {

		yaw += speedH * Input.GetAxis("Mouse X");
		Quaternion rotation = Quaternion.Euler(-80, yaw, 0);
		Vector3 tmp = player.transform.position;
		transform.eulerAngles = new Vector3(0, yaw, 0.0f);
		transform.position = tmp - (rotation * offset);
		transform.LookAt(player.transform);
	}

		//FirePoint.transform.position = Camera.main.ScreenToWorldPoint( new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane) );


	}
}
