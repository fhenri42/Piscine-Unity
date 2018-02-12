using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowersManager : MonoBehaviour {


	private Transform Selected;
	public Transform prefabCanon;
	public Transform prefabRocket;
	public Transform prefabGatling;
	public gameManager GameManager;
	public Text LifeText;
	public Text manaText;
	public List<Transform> towers = new List<Transform>();



	public void push(Transform tow) {

		towers.Add(tow);
		print(towers.Count);
	}

	public Transform newCannon() {

		if (GameManager.GetComponent<gameManager>().playerEnergy  >= 80) {

			Selected = GameObject.Instantiate(prefabCanon);
			Selected.name = "canon";
			Selected.transform.position = new Vector2(-4.051667f, -6.907667f);
			Selected.transform.localScale = new Vector2(1,1);
			GameManager.GetComponent<gameManager>().playerEnergy -= 80;

			return Selected;
		} else {
			return null;
		}
	}

	public Transform newGatling() {


		if (GameManager.GetComponent<gameManager>().playerEnergy  >= 50) {

			Selected = GameObject.Instantiate(prefabGatling);
			Selected.name = "gatling";
			Selected.transform.position = new Vector2(-0.8f, -7.142381f);
			Selected.transform.localScale = new Vector2(1,1);
			GameManager.GetComponent<gameManager>().playerEnergy -= 50;

			return Selected;
		} else {
			return null;
		}
	}
	public Transform newRocket() {

		if (GameManager.GetComponent<gameManager>().playerEnergy  >= 100) {

			Selected = GameObject.Instantiate(prefabRocket);
			Selected.name = "rocket";
			Selected.transform.position = new Vector2(3.08f, -7.01f);
			Selected.transform.localScale = new Vector2(1,1);
			GameManager.GetComponent<gameManager>().playerEnergy -= 100;

			return Selected;
		} else {
			return null;
		}
	}

		public bool  warningEnergy(string name) {
			if (name == "canon" && GameManager.GetComponent<gameManager>().playerEnergy  < 80) { return true; }
			if (name == "rocket" && GameManager.GetComponent<gameManager>().playerEnergy  < 100) { return true; }
			if (name == "gatling" && GameManager.GetComponent<gameManager>().playerEnergy  < 50) { return true; }
			return false;
	}
	public void destroySelect(string name) {

		if (name == "canon") { GameManager.GetComponent<gameManager>().playerEnergy += 80; }
		if(name == "rocket") { GameManager.GetComponent<gameManager>().playerEnergy += 100; }
		if (name == "gatling") { GameManager.GetComponent<gameManager>().playerEnergy += 50; }
	//	towers.RemoveAt(towers.Count - 1);
		Object.Destroy(Selected.gameObject);
	}

	void Update () {
		LifeText.text = string.Concat("Hp: ", GameManager.GetComponent<gameManager>().playerHp);
		manaText.text = string.Concat("Energy: ", GameManager.GetComponent<gameManager>().playerEnergy);
	}

	void Start () {
		LifeText.GetComponent<Text>().enabled = true;
		manaText.GetComponent<Text>().enabled = true;
	}

}
