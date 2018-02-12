using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class verifExit : MonoBehaviour {


		public Button yes;
		public Button no;
		public CommandeCenter cc;
		void Start() {
			no.GetComponent<Button>().onClick.AddListener(TaskOnClickStart);
			yes.GetComponent<Button>().onClick.AddListener(TaskOnClickExit);
		}

		void TaskOnClickStart() {
				Debug.Log("You have clicked the button! STARTTTT");
				cc.unpausse();
		}

		void TaskOnClickExit() {
				Debug.Log("You have clicked the button! EXITTT");
				 Application.Quit();
		}
	}
