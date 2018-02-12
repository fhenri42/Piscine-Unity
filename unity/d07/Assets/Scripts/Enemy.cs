using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	// Use this for initialization

	NavMeshAgent agent;
	public Transform Player;
	public GameObject machineGunImpact;
	public List<Vector3> targets = new List<Vector3>();
	public int conteur = 0;
	private bool huntingMode = false;
	private Vector3 curTargets;
	private bool nextPoint = false;
	public int hp = 10;

	void fireInThehole(RaycastHit obj) {
		machineGunImpact.SetActive(false);
		this.GetComponent<AudioSource>().Play();

		machineGunImpact.GetComponent<Transform>().position = obj.point;
		machineGunImpact.SetActive(true);
		huntingMode = true;
		curTargets = obj.point;
		if(Random.Range(0,25) == 1) {
			if(obj.transform.GetComponent<Tank>()) {
				if (obj.transform.GetComponent<Tank>().hp - 2 < 0) {
					agent.Resume();
					huntingMode = false;
					conteur = 0;
					agent.destination = targets[conteur];
				}
				obj.transform.GetComponent<Tank>().setHp();
			}
			if(obj.transform.GetComponent<Enemy>()) {
				if (obj.transform.GetComponent<Enemy>().hp - 2 < 0) {
					agent.Resume();
					huntingMode = false;
					conteur = 0;
					agent.destination = targets[conteur];
				}
				obj.transform.GetComponent<Enemy>().setHp();
			}
		}
	}
	public void setHp() {
		hp -= 2;
	}
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.destination = targets[0];
	}

	void Update() {
		machineGunImpact.SetActive(false);

		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Vector3 back = transform.TransformDirection(-Vector3.forward);
		Vector3 left = transform.TransformDirection(Vector3.left);
		Vector3 right = transform.TransformDirection(-Vector3.left);
		RaycastHit hi;
		RaycastHit hitF;
		RaycastHit hitB;
		RaycastHit hitL;
		RaycastHit hitR;

		if (Vector3.Distance(transform.position,targets[conteur]) <= 2 && !huntingMode)  {
			if (targets.Count - 1 > conteur + 1) { conteur++; }
			else { conteur = 0;}
			agent.destination = targets[conteur];
		}
		if(huntingMode) {
			agent.Stop();
			transform.LookAt(curTargets);

			if (Physics.Raycast(transform.position, curTargets, out hi ,100)) {
				if(hi.collider.tag != "tank") {
					agent.Resume();
				huntingMode = false;
				conteur = 0;
				agent.destination = targets[conteur];
			}

			}
		}


		if (Physics.Raycast(transform.position, fwd, out hitF,100)) {

			Debug.DrawLine(transform.position, hitF.point, Color.red);
			if(hitF.collider.tag == "tank") { fireInThehole(hitF);}
		}

		if (Physics.Raycast(transform.position, back, out hitB, 100)) {

			Debug.DrawLine(transform.position, hitB.point, Color.red);
			if(hitB.collider.tag == "tank") { fireInThehole(hitB);}

		}

		if (Physics.Raycast(transform.position, left, out hitL, 100)) {

			Debug.DrawLine(transform.position, hitL.point, Color.red);
			if(hitL.collider.tag == "tank") { fireInThehole(hitL);}

		}

		if (Physics.Raycast(transform.position, right, out hitR, 100)) {

			Debug.DrawLine(transform.position, hitR.point, Color.red);
			if(hitR.collider.tag == "tank") { fireInThehole(hitR);}

		}
	}
	void LateUpdate() {
		if(hp < 0) {
			Destroy(gameObject);
		}
	}

}
