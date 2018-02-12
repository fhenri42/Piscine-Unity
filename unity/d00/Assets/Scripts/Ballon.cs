using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	public int a = 0;
	public int b = 75;
	public string text;
	public bool start = true;
	public bool resp = true;
	public float time = 0;
	public GameObject balloon;

	void Update () {

		if (start) {
			transform.localScale -= new Vector3(0.01F, 0.01F, 0);
			if (transform.localScale.y >= 5.0 || transform.localScale.y <= 0.0) {
				Debug.Log("Balloon life time: "+ Mathf.RoundToInt(time)+ "s");
				transform.localScale = new Vector3(0.0F, 0.0F, 0);
				start = false;
				GameObject.Destroy(balloon);
				return;
			}
			if (a >= 100) { resp = false; }
			if (b < 0) {
				resp = true;
				b = 75;
				a = 0;
			}
			if (resp == false) { b--; }
			if (Input.GetKeyDown("space") &&  a <= 100 && resp == true) {
				transform.localScale += new Vector3(0.2F, 0.2F, 0);
				a+= 15;
			}
			if (!Input.GetKeyDown("space") && a < 100 && a > 0) { a-= 1; }
			time += Time.deltaTime;
		}
	}
}

// void OnGUI()
// {
// 	if (start) {
//
// 		if (a == 20) { StartCoroutine(Example()); }
// 		 if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString())) && a <= 20) {
// 			print(Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString())));
// 			transform.localScale += new Vector3(0.1F, 0.1F, 0);
// 			a++;
// 		}
// 	}
//}
//
// IEnumerator Example()
// {
// 	yield return new WaitForSeconds(2);
// 	a = 0;
// }
