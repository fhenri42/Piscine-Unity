using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuAnimation : MonoBehaviour {

	// Use this for initialization

	public GameObject paris;
	public GameObject titile;
	public Button start;
	public Button exit;
	public Text score;
	private bool current = true;
	private bool inverse = true;

	void parisAnimation ()  {
		if (paris.transform.localScale.y > 1.5) {
			Vector2 tmp = new Vector2(0.06027138f,0.06027127f);
			paris.transform.localScale = tmp;
		} else {
			Vector2 tmp = new Vector2(paris.transform.localScale.x + 0.01f,paris.transform.localScale.y + 0.01f);
			paris.transform.localScale = tmp;
		}
	}

	void titilesAnimation ()  {
		if (current) {
			if (titile.transform.rotation.z >= 0.04f) { current = false; }
				Quaternion tmp = Quaternion.Euler(0,0, titile.transform.rotation.z + 5);
				titile.transform.rotation = Quaternion.Slerp(titile.transform.rotation, tmp, Time.deltaTime * 2.0f);
				exit.transform.rotation = Quaternion.Slerp(titile.transform.rotation, tmp, Time.deltaTime * 2.0f);

		} else {
			if (titile.transform.rotation.z <= -0.04f) { current = true; }
			Quaternion tmp = Quaternion.Euler(0,0, titile.transform.rotation.z -  5);
			titile.transform.rotation = Quaternion.Slerp(titile.transform.rotation, tmp, Time.deltaTime * 2.0f);
			exit.transform.rotation = Quaternion.Slerp(titile.transform.rotation, tmp, Time.deltaTime * 2.0f);
		}

		if (!inverse) {
			if (start.transform.rotation.z >= 0.04f) { inverse = true; }
				Quaternion tmp = Quaternion.Euler(0,0, start.transform.rotation.z + 5);
				start.transform.rotation = Quaternion.Slerp(start.transform.rotation, tmp, Time.deltaTime * 2.0f);

		} else {
			if (start.transform.rotation.z <= -0.04f) { inverse = false; }
			Quaternion tmp = Quaternion.Euler(0,0, start.transform.rotation.z -  5);
			start.transform.rotation = Quaternion.Slerp(start.transform.rotation, tmp, Time.deltaTime * 2.0f);
		}
	}

	void TaskOnClickStart () {
		SceneManager.LoadScene("Scenes/level1");
	}
	void TaskOnClickExit () {
		print("exit Game");
		Application.Quit();
	}

	void Start () {
		InvokeRepeating("parisAnimation", 0.01f,  0.01f);
		InvokeRepeating("titilesAnimation", 0.01f,  0.05f);
		start.GetComponent<Button>().onClick.AddListener(TaskOnClickStart);
		exit.GetComponent<Button>().onClick.AddListener(TaskOnClickExit);
	}

	void Update () {
		if (score) { score.text = string.Concat("Score: ", /*.GetComponent<playerScript>().hp  ?? */ 0); }
	}
}
