using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

	public GameObject player;
	public Vector3 lastPos;
	public float sensitivity;
	private Vector3 offset;


	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	   void Start () {
         offset = transform.position - player.transform.position;
				offset = new Vector3(0,2f,0);
		 }

     void LateUpdate () {

      transform.position = player.transform.position + offset;
     }
		 void Update () {

			 yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

				 // Vector3 vp = Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
				 // vp.x -= 0.5f;
				 // vp.y -= 0.5f;
				 // vp.x *= sensitivity;
				 // vp.y *= sensitivity;
				 // vp.x += 0.5f;
				 // vp.y += 0.5f;
				 // Vector3 sp = Camera.main.ViewportToScreenPoint(vp);
         //
				 // Vector3 v = Camera.main.ScreenToWorldPoint(sp);
				 // if (lastPos.x != Input.mousePosition.x || lastPos.y != Input.mousePosition.y) {
				 // 	lastPos.x = Input.mousePosition.x;
				 // 	lastPos.y = Input.mousePosition.y;
				 // 	transform.LookAt(v, Vector3.up);
				 // }

		 }
 }
