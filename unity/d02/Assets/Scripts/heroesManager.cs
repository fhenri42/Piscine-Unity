using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroesManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Selected.Clear();
	}

	//private Hero Selected = null;
	public List<Hero> Selected = new List<Hero>();

	Vector2 togo;

	public List<Hero> heroes = new List<Hero>();


	public void pushHero(Hero hero) {
		heroes.Add(hero);
	}

	void Update () {

		if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0)) {
			Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			foreach (Hero hero in heroes) {
				if (hero.GetComponent<Rigidbody2D>().OverlapPoint(mousePosition)) {
					Selected.Add(hero);
				}
			}
		} else if (Input.GetMouseButtonDown(0) && Selected.Count != 0) {

			Vector2 mousePosition1 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			togo = Camera.main.ScreenToWorldPoint(mousePosition1);

			foreach (Hero tps in Selected) { tps.movePlayer(togo); }

		} else if (Input.GetMouseButtonDown(0)) {
			Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
			foreach (Hero hero in heroes) {

				if (hero.GetComponent<Rigidbody2D>().OverlapPoint(mousePosition)) {
					Selected.Add(hero);
				}
			}

		} else if(Input.GetMouseButtonDown(1)) {
			Selected.Clear();
		}


	}
}
