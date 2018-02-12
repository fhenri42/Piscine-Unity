using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulding : MonoBehaviour {

	// Use this for initialization

	public string name;
	public int hpHome;
	public string race;
	public Hero copHero;
	public Hero orcHero;
	public heroesManager heroes;
	// Update is called once per frame

	void unit()
	{

		if (race == "human") {

		Hero tmp = Instantiate(copHero);
		tmp.transform.position = new Vector2(-2.45f,1.2f);
		heroes.pushHero(tmp);
		} else {
			Hero tmp = Instantiate(orcHero);
			tmp.transform.position = new Vector2(3.65f,0.46f);
		}
			//Rigidbody instance = Instantiate(projectile);

	}

	void Start()
	 {
		 	if (name == "townHall") {
				InvokeRepeating("unit", 1.0f, 10.0f);
			}
	 }

	void Update () {


		if(name == "townHall") {
			if(race == "human") {
				this.GetComponent<Animator>().SetTrigger("townHall");
			} else {
				this.GetComponent<Animator>().SetTrigger("orcTownHall");
			}
		}
		if(name == "house") {
			if(race == "human") {
				this.GetComponent<Animator>().SetTrigger("house");
			} else {
				this.GetComponent<Animator>().SetTrigger("orcHouse");
			}
		}
		if(name == "mine") {
			if (race == "human") {
				this.GetComponent<Animator>().SetTrigger("mine");
			} else {
				this.GetComponent<Animator>().SetTrigger("orcMine");
			}
		}
		if(name == "port") {
			if (race == "human") {
				this.GetComponent<Animator>().SetTrigger("port");
			} else {
				this.GetComponent<Animator>().SetTrigger("orcPort");
			}
		}
		if(name == "tower") {
			if (race == "human") {
				this.GetComponent<Animator>().SetTrigger("tower");
			} else {
				this.GetComponent<Animator>().SetTrigger("orcTower");
			}
		}
	}
}
