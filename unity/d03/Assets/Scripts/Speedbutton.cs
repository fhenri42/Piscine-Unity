using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedbutton : MonoBehaviour {



	public gameManager GM;
	public CommandeCenter cc;

	void OnMouseDown()
	{
		if (this.name == "speed-" && cc.GetComponent<CommandeCenter>().GameSpeed - 1 > 0) { cc.GetComponent<CommandeCenter>().GameSpeed -= 1; GM.changeSpeed(cc.GetComponent<CommandeCenter>().GameSpeed); }
		if (this.name == "speed+" && cc.GetComponent<CommandeCenter>().GameSpeed + 1 < 7) { cc.GetComponent<CommandeCenter>().GameSpeed += 1; GM.changeSpeed(cc.GetComponent<CommandeCenter>().GameSpeed); }
		if (this.name == "play/pause") {
			if (cc.GetComponent<CommandeCenter>().semiPause == true) {
				GM.pause(cc.GetComponent<CommandeCenter>().semiPause);
				cc.GetComponent<CommandeCenter>().semiPause= false;
			} else if (!cc.GetComponent<CommandeCenter>().semiPause) {
				GM.pause(cc.GetComponent<CommandeCenter>().semiPause);
				cc.GetComponent<CommandeCenter>().semiPause = true;
			}
		}

	}

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
