using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uigame : MonoBehaviour {


	public GameObject player;

	private Vector3 offset;


	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;
	public float damping = 1;

	void Start () {
		// offset = transform.position - player.transform.position;
		// offset = new Vector3(-30,10,0);
	}

	void Update () {



		// yaw += speedH * Input.GetAxis("Mouse X");
		// Quaternion rotation = Quaternion.Euler(0, yaw, 0);
		// Vector3 tmp = player.transform.position;
		// tmp.y =+ 40;
		// transform.position = tmp - (rotation * offset);
		// transform.LookAt(player.transform);
		// transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

	}

}
