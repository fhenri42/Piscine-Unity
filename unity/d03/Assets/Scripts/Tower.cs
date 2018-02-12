using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Tower : MonoBehaviour {

	// Use this for initialization
	private bool dragging = false;
	private float distance;
	public TowersManager towMang;
	private Transform Selected = null;
	public Text damageText;
	public Text rangeText;
	public Text priceText;
	public Text energyText;
	public Text reloadText;
	private bool redOnce = false;


	void Start () {

	}

	void OnMouseDown()
	{

		 if (this.name == "canon") { Selected = towMang.newCannon(); }
		 if (this.name == "gatling") { Selected = towMang.newGatling(); }
		 if (this.name == "rocket") { Selected = towMang.newRocket(); }
		 if(Selected == null) {
			 energyText.GetComponent<Text>().enabled = true;
			 energyText.text = string.Concat("Not enough energy");

			 return; }
		 damageText.GetComponent<Text>().enabled = true;
		 rangeText.GetComponent<Text>().enabled = true;
		 priceText.GetComponent<Text>().enabled = true;
		 reloadText.GetComponent<Text>().enabled = true;

		 if (Selected) {

		 damageText.text = string.Concat("Damage: ", Selected.GetComponent<towerScript>().damage);
		 priceText.text = string.Concat(Selected.GetComponent<towerScript>().energy, " $");
		 rangeText.text = string.Concat("Range: ", Selected.GetComponent<towerScript>().range);
		 reloadText.text = string.Concat("Reload: ", Selected.GetComponent<towerScript>().fireRate);
	 }
			distance = Vector3.Distance(transform.position, Camera.main.transform.position);
			dragging = true;
			//print("Dammage =>" +Selected.GetComponent<towerScript>().damage);

	}


	void OnMouseUp()
	{
			dragging = false;
			if(Selected == null) {  energyText.GetComponent<Text>().enabled = false; return; }
			//Destroy(gameObject);
			damageText.GetComponent<Text>().enabled = false;
			rangeText.GetComponent<Text>().enabled = false;
			priceText.GetComponent<Text>().enabled = false;
			reloadText.GetComponent<Text>().enabled = false;
			if (Selected.transform.position.y <= -5) { towMang.destroySelect(Selected.name); return; }

			Regex regex = new Regex("empty");
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0.1f);
			RaycastHit2D[] hitTest = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 0.1f);

			foreach (Transform l in towMang.GetComponent<TowersManager>().towers) {

				if((Selected.position.y <= l.position.y + 1 && Selected.position.y >= l.position.y - 1)  &&(Selected.position.x <= l.position.x + 1 && Selected.position.x >= l.position.x - 1)) {
					towMang.destroySelect(Selected.name);
					return;
				}
			}
			if (hit) {
				Match match = regex.Match(hit.collider.name);
		 if (!match.Success) { towMang.destroySelect(Selected.name); return; }
			}
				towMang.push(Selected);

	}

	void Update()
	{
			if (dragging)
			{
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					Vector3 rayPoint = ray.GetPoint(distance);
					Selected.transform.position = rayPoint;

			}
			if (towMang.warningEnergy(this.name)) {
				redOnce = true;
				this.GetComponent<SpriteRenderer>().color = Color.red;
			} else if (redOnce) {
				redOnce = false;
					this.GetComponent<SpriteRenderer>().color = Color.white;

			}
	}
}
