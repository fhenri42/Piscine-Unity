using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CommandeCenter : MonoBehaviour {

	// Use this for initialization
	public TowersManager towMang;
	public gameManager GM;
	public bool onPause = false;
	public  GameObject menuPause;
	public  GameObject verifExit;
	public  GameObject gamePanel;

	public Text score;
	public  GameObject gameOver;
	public float GameSpeed = 0;
	public bool semiPause = true;
	public ennemyScript test;
	private string rank;
	private bool victoire = false;



	void Start () {

	}

	public void restart() {
		print("restart");
		 SceneManager.LoadScene("Scenes/ex01", LoadSceneMode.Single);
	}
	public void endOfGame(int s, int energy, int hp) {
		gameOver.gameObject.SetActive(true);
		gamePanel.gameObject.SetActive(false);

		if(hp <= 0) {
			gameOver.gameObject.transform.GetChild(0).gameObject.SetActive(true);
			gameOver.gameObject.transform.GetChild(1).gameObject.SetActive(true);
		} else {
			gameOver.gameObject.transform.GetChild(3).gameObject.SetActive(true);
			gameOver.gameObject.transform.GetChild(4).gameObject.SetActive(true);
		}

		 if(hp >= 20 && energy >= 300) { rank = "A+"; }
		 else if(hp <= 20 && hp >= 15 && energy <= 300 && energy >= 250) { rank = "A-"; }
		 else if(hp <= 15 && hp >= 10 && energy <= 250 && energy >= 200) { rank = "B+"; }
		 else if(hp <= 10 && hp >= 15 || energy <= 200 && energy >= 100) { rank = "B-"; }
		 else if(hp <= 5 && hp >= 0 || energy <= 100 && energy >= 50) { rank = "C+"; }
		 else if(hp <= 0  || energy <= 50 && energy >= 0) { rank = "C-"; }
		 else if(hp <= 0  || energy <= 0) { rank = "F"; }
		 if (s == 0) { rank ="YOUR ARE BAD"; }
		 if (score) { score.text = "Scrore: " + s.ToString() + " Your rank: "  + rank; }

	}
	public void verifExitFunc() {
		verifExit.gameObject.SetActive(true);
		menuPause.gameObject.SetActive(false);

	}
	public void  unpausse() {
		GM.pause(false);
		verifExit.gameObject.SetActive(false);
		gamePanel.gameObject.SetActive(true);
		menuPause.gameObject.SetActive(false);
		menuPause.transform.SetAsLastSibling();

		onPause = false;
	}
	void Update () {

	if(test) { victoire = test.checkLastEnemy(); }
	if (victoire) {

		endOfGame(GM.GetComponent<gameManager>().score, GM.GetComponent<gameManager>().playerStartEnergy, GM.GetComponent<gameManager>().playerMaxHp);
	}
	if (Input.GetKey("escape") && onPause == false) {
		onPause = true;
		if (GM) {GM.pause(true); }
		if (gamePanel) gamePanel.gameObject.SetActive(false);
		if (gameOver) gameOver.gameObject.SetActive(false);
		if (menuPause) menuPause.gameObject.SetActive(true);
	}
}

}
