using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	public GameObject cubeA;
	public GameObject cubeD;
	public GameObject cubeS;
	private float timer;
	public float spawnTime = 0;
	public float startP;
	public int letter;
	// Update is called once per frame
	void Update () {
		if (timer >= Random.Range(1, spawnTime)) {
			timer = 0;
			Vector3 newPose = new Vector3(startP,3.261671F,0);
			if (letter == 0) { GameObject.Instantiate(cubeA, newPose, Quaternion.identity);}
			else if (letter == 2) { GameObject.Instantiate(cubeD, newPose, Quaternion.identity); }
			else if (letter == 1) { GameObject.Instantiate(cubeS, newPose, Quaternion.identity); }
		}

		timer += Time.deltaTime;
	}
}
