using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu : MonoBehaviour {


	public Button start;
	public Button exit;

	void Start() {
		start.GetComponent<Button>().onClick.AddListener(TaskOnClickStart);
		exit.GetComponent<Button>().onClick.AddListener(TaskOnClickExit);
	}

	void TaskOnClickStart() {
			Debug.Log("You have clicked the button! STARTTTT");
			 SceneManager.LoadScene("Scenes/ex01", LoadSceneMode.Single);
	}

	void TaskOnClickExit() {
			Debug.Log("You have clicked the button! EXITTT");
			 Application.Quit();
	}
}
