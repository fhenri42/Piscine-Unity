using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class menuPause : MonoBehaviour {


	public Button start;
	public Button exit;
	public Button restart;
	public Button nextLvl;
	public CommandeCenter cc;
	void Start() {
	if (start)	start.GetComponent<Button>().onClick.AddListener(TaskOnClickStart);
	if (exit)	exit.GetComponent<Button>().onClick.AddListener(TaskOnClickExit);
	if (nextLvl)	nextLvl.GetComponent<Button>().onClick.AddListener(TaskOnClicNextLxl);
	if (restart)	restart.GetComponent<Button>().onClick.AddListener(TaskOnClickRestart);
	}

	void TaskOnClickStart() {
			Debug.Log("You have clicked the button! STARTTTT");
			cc.unpausse();
	}

	void TaskOnClickExit() {
			cc.verifExitFunc();
			//Debug.Log("You have clicked the button! EXITTT");
			// Application.Quit();
	}
	void TaskOnClicNextLxl() {
		print("Welcome to the nextLXL MA GEUL");
		cc.restart();
		
	}
	void TaskOnClickRestart() {
			cc.restart();
	}
}
