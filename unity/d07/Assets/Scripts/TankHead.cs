using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHead : MonoBehaviour {

	public Transform GameCamera;
	public GameObject machineGunImpact;
	public GameObject missileImpact;
	public float stopCount = 0;
	public float ammo = 10;
	public AudioClip gun;
	public AudioClip Missile;


	void fireEasy(RaycastHit obj) {
		missileImpact.SetActive(false);
			this.GetComponent<AudioSource>().clip = gun;
	this.GetComponent<AudioSource>().Play();
		missileImpact.GetComponent<Transform>().position = obj.point;
		missileImpact.SetActive(true);
		stopCount = 0.1f;
		if(obj.transform.GetComponent<Enemy>()) {
			obj.transform.GetComponent<Enemy>().setHp();
		}

	}
	void fireHard(RaycastHit obj) {

		machineGunImpact.SetActive(false);
		this.GetComponent<AudioSource>().clip = Missile;
this.GetComponent<AudioSource>().Play();
		machineGunImpact.GetComponent<Transform>().position = obj.point;
		machineGunImpact.SetActive(true);
		if(obj.transform.GetComponent<Enemy>()) {
			obj.transform.GetComponent<Enemy>().setHp();
		}
		stopCount = 0.1f;



	}
	void Update () {

		Quaternion CharacterRotation = GameCamera.transform.rotation;
		CharacterRotation.x = 0;
		CharacterRotation.z = 0;
		transform.rotation = CharacterRotation;

		if(stopCount != 0) {
			stopCount += Time.deltaTime;
		}
		if (stopCount > 2.5) {
			machineGunImpact.SetActive(false);
			stopCount = 0;
		}
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit rayHit;
		if (Input.GetMouseButtonDown(0)) {
			if (Physics.Raycast(transform.position, fwd, out rayHit, 400)) {
				fireEasy(rayHit);

				Debug.DrawLine(transform.position, rayHit.point, Color.red);
			}
		}

		if (Input.GetMouseButtonDown(1) && ammo > 0) {
			if (Physics.Raycast(transform.position, fwd, out rayHit, 500)) {
				ammo--;
				fireHard(rayHit);
				Debug.DrawLine(transform.position, rayHit.point, Color.red);
			}
		}


	}
}
